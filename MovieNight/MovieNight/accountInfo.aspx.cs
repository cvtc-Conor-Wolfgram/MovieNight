using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Web.Script.Serialization;

namespace MovieNight
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private MovieNightContext db = new MovieNightContext();
        private User currentUser;
        private List<Movie> usersMovies;

        protected void Page_Init(object sender, EventArgs e)
        {

            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];
            }
            else
            {
                Response.Redirect("CreateAccount.aspx");
            }

            //Account Info
            nameLbl.Text = currentUser.fName;
            userNameLbl.Text = currentUser.userName;
            emailLbl.Text = currentUser.email;

            //The User's Movies
            displayMoviesList(currentUser);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnJoinGroup_Click(object sender, EventArgs e)
        {
            if (db.Database.SqlQuery<User>("SELECT * FROM [User] INNER JOIN UserGroup ON [User].userID = Usergroup.userID INNER JOIN [Group] on Usergroup.groupID = [Group].groupID WHERE [User].userID = " + currentUser.userID + " AND [Group].groupCode = " + txtGroupCode.Text).FirstOrDefault() == null)
            {
                Group group = new Group();
                group = db.Database.SqlQuery<Group>("SELECT * FROM [GROUP] WHERE [GROUP].groupCode = " + txtGroupCode.Text).FirstOrDefault();

                try
                {
                    int lastUserJoinNum = db.Database.SqlQuery<int>("SELECT joinNumber FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID WHERE [UserGroup].groupID = " + group.groupID + "ORDER BY [UserGroup].joinNumber DESC").FirstOrDefault();

                    lastUserJoinNum++;

                    db.Database.ExecuteSqlCommand("INSERT INTO UserGroup (userID, groupID, joinNumber, turnToPick) VALUES (" + currentUser.userID + ", '" + group.groupID + "', '" + lastUserJoinNum + "', '0')");

                    UserGroup newUserGroup = new UserGroup();
                    newUserGroup.userID = currentUser.userID;
                    newUserGroup.groupID = group.groupID;
                    newUserGroup.joinNumber = lastUserJoinNum;
                    newUserGroup.turnToPick = 0;
                    db.userGroup.Add(newUserGroup);

                    lblJoinResponse.Text = "Group has been Joined.";

                } catch (NullReferenceException ex)
                {
                    lblJoinResponse.Text = "Invalid Group Number.";
                }

                

            } else
            {
                lblJoinResponse.Text = "You are already a part of this group.";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Group group = new Group();

            group.groupName = txtGroupName.Text;
            group.ownerID = currentUser.userID;
            group.groupCode = new Random().Next(10000, 100000);

            MovieNightContext context = new MovieNightContext();
            context.groups.Add(group);
            context.SaveChanges();

            UserGroup newUserGroup = new UserGroup();
            newUserGroup.userID = currentUser.userID;
            newUserGroup.groupID = group.groupID;
            newUserGroup.turnToPick = 1;
            newUserGroup.joinNumber = 1;
            context.userGroup.Add(newUserGroup);
            context.SaveChanges();

            Response.Redirect("Group.aspx?groupID=" + group.groupID);
        }

        protected void displayMoviesList(User picker)
        {
            //List of current movies to be picked
            usersMovies = db.movies.SqlQuery("SELECT Movie.movieID, Movie.omdbCode FROM Movie INNER JOIN UserMovie on Movie.movieID = UserMovie.movieID WHERE userID = " + picker.userID).ToList<Movie>();
            phUserMovies.Controls.Clear();
            String html = "<div class=\"row\">\n";
            phUserMovies.Controls.Add(new Literal { Text = html });
            foreach (Movie movie in usersMovies)
            {

                string url = "http://www.omdbapi.com/?&apikey=b9bb3ece&i=" + movie.omdbCode;
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    ImdbEntity imdbEntity = new ImdbEntity();
                    imdbEntity = oJS.Deserialize<ImdbEntity>(json);
                    if (imdbEntity.Response == "True")
                    {
                        html = "";
                        html += "<div class=\"col - md - 3\" style=\"padding: 1rem;\">\n";
                        html += "\t<div class=\"well text-center\">\n";
                        html += "\t\t<img height=\"420px\" src='" + imdbEntity.Poster + "'>\n";
                        html += "\t\t<h5>" + imdbEntity.Title + " (" + imdbEntity.Year + ")</h5>";
                        html += "\t\t<a class=\"btn btn-primary\" href=\"https://www.imdb.com/title/" + imdbEntity.imdbID + "\" style=\"margin-right: 1rem\">Link to IMDB</a>";
                        phUserMovies.Controls.Add(new Literal { Text = html });

                        Button btnAddMovie = new Button();
                        btnAddMovie.Click += new EventHandler(btnRemove_Click);
                        btnAddMovie.CssClass = "btn btn-primary";
                        btnAddMovie.Text = "Remove Movie";
                        btnAddMovie.CommandName = "removeMovie";
                        btnAddMovie.CommandArgument = imdbEntity.imdbID;

                        phUserMovies.Controls.Add(btnAddMovie);

                        html = "";
                        html += "</div>";
                        html += "</div>";
                        phUserMovies.Controls.Add(new Literal { Text = html });

                    }
                    else
                    {
                        html += "<li>\n";
                        html += "\t<p>Movies not added</p>\n";
                        html += "</li>\n";

                    }


                }





            }
            html = "";
            html += "</div>\n";
            phUserMovies.Controls.Add(new Literal { Text = html });
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            switch (btn.CommandName)
            {
                case "removeMovie":
                    //SQL to add movie goes here
                    Movie movieToRemove = new Movie();
                    movieToRemove = db.movies.SqlQuery("SELECT * FROM Movie WHERE omdbCode = '" + btn.CommandArgument + "'").FirstOrDefault();

                    UserMovie userMovieToRemove = new UserMovie();
                    userMovieToRemove.userID = currentUser.userID;
                    userMovieToRemove.movieID = movieToRemove.movieID;

                    db.userMovie.Attach(userMovieToRemove);
                    db.userMovie.Remove(userMovieToRemove);
                    db.SaveChanges();

                    displayMoviesList(currentUser);

                    break;
            }

        }
    }
}