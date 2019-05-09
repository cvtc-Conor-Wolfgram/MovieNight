using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        private User picker;
        private User currentUser;
        User groupOwner;
        private Group pageGroup = new Group();
        private MovieNightContext db = new MovieNightContext();
        private List<Movie> nextMoviesAvalible = new List<Movie>();
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

            if (Request.QueryString["groupID"] != null)
            {

                int currentGroupID = Convert.ToInt16(Request.QueryString["groupID"]);
                //Getting page and owner Info
                pageGroup = db.groups.SqlQuery("Select * " +
                    "FROM [Group] WHERE groupID=" + currentGroupID).FirstOrDefault();

                groupName.InnerText = pageGroup.groupName;
                String sql = "SELECT * FROM [User] WHERE [User].userID = " + pageGroup.ownerID;
                groupOwner = db.users.SqlQuery("SELECT * FROM [User] WHERE [User].userID = " + pageGroup.ownerID).FirstOrDefault();

                if (groupOwner != null)
                {
                    ownerName.InnerText = "Group Owner: " + groupOwner.fName + " " + groupOwner.lName;
                }
                else
                {
                    ownerName.InnerText = "Unable to Retrieve Owner";
                }


                //Setting members list and who's turn it is to pick
                members = db.users.SqlQuery("SELECT * " +
                    "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                    "WHERE [UserGroup].groupID = " + currentGroupID +
                    " ORDER BY [UserGroup].joinNumber").ToList<User>();

                String html = "";
                foreach (User member in members)
                {
                    

                    if (db.userGroup.Find(member.userID, currentGroupID).turnToPick == 1)
                    {
                        picker = member;
                        html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">" + member.fName + " " + member.lName + "";
                        html += "\t<span class=\"badge badge-primary badge - pill\">Picker</span>";
                        html += "</li>\n";
               
                    }
                    else
                    {
                        html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">" + member.fName + " " + member.lName + "</li>";
                    }
                }
                phMembers.Controls.Clear();
                phMembers.Controls.Add(new Literal { Text = html });

                displayMoviesList(picker);

            }
            else
            {
                Response.Redirect("Group.aspx?groupID=1");
            }


        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void finishedMovie_Click(object sender, EventArgs e)
        {
            int currentGroupID = Convert.ToInt16(Request.QueryString["groupID"]);

            //Changes who's turn it is to pick after a button click
            for (int i = 0; i < members.Count; i++) //For all the members
            {
                if (db.userGroup.Find(members[i].userID, currentGroupID).turnToPick == 1) //Find the person who is currently picking
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 0 WHERE userID = " + members[i].userID + "and groupID = " + currentGroupID);
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 1 WHERE userID = " + members[i + 1].userID + "and groupID = " + currentGroupID);
                        picker = members[i + 1];

                        displayMoviesList(picker);

                    }
                    catch (Exception)
                    {

                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 0 WHERE userID = " + members[i].userID + "and groupID = " + currentGroupID);
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 1 WHERE userID = " + members[0].userID + "and groupID = " + currentGroupID);
                        picker = members[0];

                        displayMoviesList(picker);
                    }

                    break;

                }
            }
        }



        protected void displayMoviesList(User picker)
        {
            movieDropdown.Items.Clear();
            movieDropdown.Items.Add("Select a Movie");
  
            //List of current movies to be picked
            nextMoviesAvalible = db.movies.SqlQuery("SELECT Movie.movieID, Movie.omdbCode FROM Movie INNER JOIN UserMovie on Movie.movieID = UserMovie.movieID WHERE userID = " + picker.userID + "ORDER BY dateAdded Desc").ToList<Movie>();

            phNextMovies.Controls.Clear();
            String html = "";
            phNextMovies.Controls.Add(new Literal { Text = html });
          
            foreach (Movie movie in nextMoviesAvalible)
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
                        ListItem item = new ListItem(imdbEntity.Title.ToString());
                        
                        movieDropdown.Items.Add(item);

                        
                        
                    }
                    else
                    {
                        html += "<li>\n";
                        html += "\t<p>Movie not added</p>\n";
                        html += "</li>\n";

                    }

                    
                }





            }


            int currentGroupID = Convert.ToInt16(Request.QueryString["groupID"]);
            phMembers.Controls.Clear();
            html = "";

            foreach (User member in members)
            {


                if (member == picker)
                {
                    
                    html += "<li class=\"list-group-item d-flex bg-secondary justify-content-between align-items-center\">" + member.fName + " " + member.lName + "";
                    html += "\t<span class=\"badge badge-primary badge - pill\">Picker</span>";
                    html += "</li>\n";
                }
                else
                {
                    html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">" + member.fName + " " + member.lName + "</li>";
                }
            }

            phMembers.Controls.Add(new Literal { Text = html });
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

        protected void createEvent_Click(object sender, EventArgs e)
        {
            Session.Add("group", pageGroup);
            Response.Redirect("createEvent.aspx");
        }

        protected void movieDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMovie = movieDropdown.SelectedItem.Text;
            var html = "";
            phNextMovies.Controls.Clear();
            string url = "http://www.omdbapi.com/?&apikey=b9bb3ece&t=" + selectedMovie;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                ImdbEntity imdbEntity = new ImdbEntity();
                imdbEntity = oJS.Deserialize<ImdbEntity>(json);
                if (imdbEntity.Response == "True")
                {

                    html = "";


                    html += "<div \" id=\"" + imdbEntity.imdbID + "\">";

                    html += "\t<div class=\"well text-center\">\n";

                    if (imdbEntity.Poster == "N/A")
                    {
                        html += "\t\t<img height=\"420px\" src='images/defaultPoster.jpg'>\n";
                    }
                    else
                    {
                        html += "\t\t<img height=\"420px\" width=\"284px\" style=\"border-radius: 5px; box-shadow: 5px 5px 5px grey; \"src='" + imdbEntity.Poster + "'>\n";
                    }

                    html += "\t\t<h5 style=\"text-shadow: 5px 5px 5px grey; \">" + imdbEntity.Title + " (" + imdbEntity.Year + ")</h5>";


                    html += "\t\t<a class=\"btn btn-primary\" href=\"https://www.imdb.com/title/" + imdbEntity.imdbID + "\" target=\"_blank\" style=\"margin-right: 1rem\">Link to IMDB</a>";
                    phNextMovies.Controls.Add(new Literal { Text = html });
                    if (picker.userID == currentUser.userID || currentUser.userID == groupOwner.userID)
                    {
                        Button btnAddMovie = new Button();
                        btnAddMovie.ID = "addMovie" + imdbEntity.imdbID;
                        btnAddMovie.Click += new EventHandler(btnRemove_Click);
                        btnAddMovie.CssClass = "btn btn-primary";
                        btnAddMovie.Text = "Remove Movie";
                        btnAddMovie.CommandName = "removeMovie";
                        btnAddMovie.CommandArgument = imdbEntity.imdbID;
                        phNextMovies.Controls.Add(btnAddMovie);
                    }

                    html = "";
                    html += "</div>";
                    html += "</div>";

                    phNextMovies.Controls.Add(new Literal { Text = html });
                }
            }
        }
    }
}