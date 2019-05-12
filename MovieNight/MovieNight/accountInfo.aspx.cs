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
        List<Group> groups = new List<Group>();
        private List<User> members = new List<User>();

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
            var count = 1;
            try
            {
                groups = db.groups.SqlQuery("Select [Group].groupID, groupName, groupCode, ownerID " +
                "FROM [Group] INNER JOIN UserGroup on UserGroup.groupID = [Group].groupID " +
                "WHERE UserGroup.userID = " + currentUser.userID +
                " ORDER BY [UserGroup].joinNumber DESC").ToList<Group>();
            
            
            String html = "";
            foreach (Group group in groups)
            {
               
                    int currentGroupID = group.groupID;
                    members = db.users.SqlQuery("SELECT * " +
                    "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                    "WHERE [UserGroup].groupID = " + currentGroupID +
                    " ORDER BY [UserGroup].joinNumber").ToList<User>();

                html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">\n";
                html += "\t<a href='Group.aspx?groupID=" + group.groupID + "'>" + group.groupName + "</a>\n";
                html += "\t<span class=\"badge badge-primary badge - pill\">Members: " + members.Count() + "</span>";
                html += "</li>\n";

                count += 1;
                    
               
                
            }

            phGroupList.Controls.Add(new Literal { Text = html });
            }
            catch (Exception)
            {
                var html = "<li class=\"list-group-item d-flex justify-content-between align-items-center\">\n";
                html += "\t<p>Unable to Access Groups</p>\n";
                html += "</li>\n";
                phGroupList.Controls.Add(new Literal { Text = html });
            }
        }

        protected void btnJoinGroup_Click(object sender, EventArgs e)
        {
            try
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

                    }
                    catch (NullReferenceException ex)
                    {
                        lblJoinResponse.Text = "Invalid Group Number.";
                    }



                }
                else
                {
                    lblJoinResponse.Text = "You are already a part of this group.";
                }
            } catch (Exception)
            {
                lblJoinResponse.Text = "Unable to join group";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            try
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
            } catch (Exception)
            {
                lblCreateResponse.Text = "Unable to create group";
            }
        }

        protected void displayMoviesList(User picker)
        {
            //List of current movies to be picked
            try
            {
                usersMovies = db.movies.SqlQuery("SELECT Movie.movieID, Movie.omdbCode FROM Movie INNER JOIN UserMovie on Movie.movieID = UserMovie.movieID WHERE userID = " + picker.userID + "ORDER BY dateAdded Desc ").ToList<Movie>();
                phUserMovies.Controls.Clear();
                phUserMovieTab.Controls.Clear();
                String html = "";
                phUserMovies.Controls.Add(new Literal { Text = html });
                int count = 0;
                var active = "";
                var show = "";
                var space = "";
                if (usersMovies.Count() == 0)
                {
                    html += "<h4>No Movies to Display.</h4>";
                    html += "<p>Add movies to your list <a href=\"movieSearch.aspx\" style=\"color: blue;\">here</a>.</p>";
                    phUserMovieTab.Controls.Add(new Literal { Text = html });

                    html = "";
                    html += "\t\t\t<img height=\"480px\" width=\"360px\" class=\"img - responsive\"  src='images/defaultPoster.jpg'>\n";
                    phUserMovies.Controls.Add(new Literal { Text = html });
                }
                else
                {
                    foreach (Movie movie in usersMovies)
                {
                    count += 1;

                    if (count == 1)
                    {
                        active = "active";
                        show = "show";
                        space = " ";
                    }
                    else
                    {
                        active = "";
                        show = "";
                        space = "";
                    }

                    string url = "http://www.omdbapi.com/?&apikey=b9bb3ece&i=" + movie.omdbCode;
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString(url);
                        JavaScriptSerializer oJS = new JavaScriptSerializer();
                        ImdbEntity imdbEntity = new ImdbEntity();
                        imdbEntity = oJS.Deserialize<ImdbEntity>(json);
                        if (imdbEntity.Response == "True" && count <= 4)
                        {
                            html = "";

                            html += "<li class=\"nav-item\">";
                            html += "<a class=\"nav-link" + space + active + "\" data-toggle=\"tab\" href=\"#" + movie.omdbCode + "\">Movie " + count + "</a>";
                            html += "</li>";
                            phUserMovieTab.Controls.Add(new Literal { Text = html });


                            html = "";

                            html += "<div class=\"tab-pane fade" + space + active + space + show + space + "\" id=\"" + movie.omdbCode + "\">";

                            html += "\t<div class=\"hovereffect\" style=\"height: 496px; width: 360px;\">\n";
                            if (imdbEntity.Poster == "N/A")
                            {
                                html += "\t\t\t<img height=\"496px\" width=\"360px\" class=\"img - responsive\"  src='images/defaultPoster.jpg'>\n";
                            }
                            else
                            {
                                html += "\t\t<img height=\"496px\" width= \"360px\"  class=\"img - responsive\" src='" + imdbEntity.Poster + "'>\n";
                            }
                            html += "<div class=\"overlay\">";
                            html += "\t\t<h2>" + imdbEntity.Title + " (" + imdbEntity.Year + ")</h2>";
                            html += "<p class=\"text-muted\" style=\"text-align: left; padding: 1rem;\">" + imdbEntity.Plot + "</p>";
                            html += "<ul>";
                            html += "<li><p style=\"float: left; padding-left: 1rem;\">Runtime: " + imdbEntity.Runtime + "</p><p style=\"float: right; padding-right: 1rem;\">Rated:" + imdbEntity.Rated + "</li>";
                            html += "</ul>";

                            html += "\t\t<a class=\"info link1 text-small\" href=\"https://www.imdb.com/title/" + imdbEntity.imdbID + "\" style=\"margin-right: 1rem\">Link to IMDB</a>";
                            phUserMovies.Controls.Add(new Literal { Text = html });

                            LinkButton btnAddMovie = new LinkButton();
                            btnAddMovie.ID = "addMovie" + imdbEntity.imdbID;
                            btnAddMovie.Click += new EventHandler(btnRemove_Click);
                            btnAddMovie.CssClass = "info link2 text-small";
                            btnAddMovie.Text = "Remove Movie";
                            btnAddMovie.CommandName = "removeMovie";
                            btnAddMovie.CommandArgument = imdbEntity.imdbID;

                            phUserMovies.Controls.Add(btnAddMovie);

                            html = "";
                            html += "\t</div>";
                            html += "</div>\n";
                            html += "</div>";
                            phUserMovies.Controls.Add(new Literal { Text = html });

                        }
                        else
                        {
                            html += "\t\t\t<img height=\"496px\" width=\"360px\" class=\"img - responsive\"  src='images/defaultPoster.jpg'>\n";
                            phUserMovies.Controls.Add(new Literal { Text = html });
                        }


                    }





                }
                }
                

            } catch (Exception)
            {
                //Movies will not display
                phUserMovies.Controls.Add(new Literal { Text = "Unable to display movies" });
            }
            
            
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;

            switch (btn.CommandName)
            {
                case "removeMovie":
                    //SQL to add movie goes here
                    try
                    {
                        Movie movieToRemove = new Movie();
                        movieToRemove = db.movies.SqlQuery("SELECT * FROM Movie WHERE omdbCode = '" + btn.CommandArgument + "'").FirstOrDefault();

                        UserMovie userMovieToRemove = new UserMovie();
                        userMovieToRemove.userID = currentUser.userID;
                        userMovieToRemove.movieID = movieToRemove.movieID;

                        db.userMovie.Attach(userMovieToRemove);
                        db.userMovie.Remove(userMovieToRemove);
                        db.SaveChanges();

                        displayMoviesList(currentUser);
                    } catch (Exception) {
                        //Movie won't change, should be self explanitory
                    }

                    break;
            }

        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}