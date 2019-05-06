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
    public partial class WebForm5 : System.Web.UI.Page
    {
        private MovieNightContext db = new MovieNightContext();
        User currentUser;

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

            displayMoviesList(currentUser);
        }


        protected void displayMoviesList(User picker)
        {
            //List of current movies to be picked
            List<Movie> moviesAvalible = db.movies.SqlQuery("SELECT Movie.movieID, Movie.omdbCode FROM Movie INNER JOIN UserMovie on Movie.movieID = UserMovie.movieID WHERE userID = " + picker.userID).ToList<Movie>();
            String html = "";

            phMovies.Controls.Clear();
            html += "<div class=\"row\">\n";
            phMovies.Controls.Add(new Literal { Text = html });

            foreach (Movie movie in moviesAvalible)
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
                        if (imdbEntity.Poster == "N/A")
                        {
                            html += "\t\t<img height=\"420px\" src='images/defaultPoster.jpg'>\n";
                        }
                        else
                        {
                            html += "\t\t<img height=\"420px\" src='" + imdbEntity.Poster + "'>\n";
                        }
                        html += "\t\t<h3>" + imdbEntity.Title + " (" + imdbEntity.Year + ")</h3>";
                        html += "\t\t<a class=\"btn btn-primary\" href=\"https://www.imdb.com/title/" + imdbEntity.imdbID + "\" style=\"margin-right: 1rem\">Link to IMDB</a>";
                        phMovies.Controls.Add(new Literal { Text = html });

                        Button btnAddMovie = new Button();
                        btnAddMovie.ID = "addMovie" + imdbEntity.imdbID;
                        btnAddMovie.Click += new EventHandler(btnRemove_Click);
                        btnAddMovie.CssClass = "btn btn-primary";
                        btnAddMovie.Text = "Remove Movie";
                        btnAddMovie.CommandName = "removeMovie";
                        btnAddMovie.CommandArgument = imdbEntity.imdbID;
                        phMovies.Controls.Add(btnAddMovie);

                        html = "";
                        html += "</div>";
                        html += "</div>";
                        phMovies.Controls.Add(new Literal { Text = html });

                    }
                    else
                    {
                        html += "<li>\n";
                        html += "\t<p>No movies added</p>\n";
                        html += "</li>\n";

                    }




                }





            }

            html = "";
            html += "</div>\n";
            phMovies.Controls.Add(new Literal { Text = html });

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