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
            try
            {
                //List of current movies to be picked
                List<Movie> moviesAvalible = db.movies.SqlQuery("SELECT Movie.movieID, Movie.omdbCode FROM Movie INNER JOIN UserMovie on Movie.movieID = UserMovie.movieID WHERE userID = " + picker.userID).ToList<Movie>();
                if (moviesAvalible != null) {
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
                                html += "<div class=\"col-lg-4\" style=\" margin-top: 1rem; height: 450px; width: 314px\">\n";
                                html += "\t<div class=\"hovereffect\" style=\"height: 450px; width: 314px\">\n";
                                if (imdbEntity.Poster == "N/A")
                                {
                                    html += "\t\t\t<img height=\"450px\" width=\"314px\" class=\"img - responsive\"  src='images/defaultPoster.jpg'>\n";
                                }
                                else
                                {
                                    html += "\t\t<img height=\"450px\" width= \"314px\"  class=\"img - responsive\" src='" + imdbEntity.Poster + "'>\n";
                                }
                                html += "<div class=\"overlay\">";
                                html += "\t\t<h2>" + imdbEntity.Title + " (" + imdbEntity.Year + ")</h2>";
                                html += "<p class=\"text-muted\" style=\"text-align: left; padding: 1rem;\">" + imdbEntity.Plot + "</p>";
                                html += "<ul>";
                                html += "<li><p style=\"float: left; padding-left: 1rem;\">Runtime: " + imdbEntity.Runtime + "</p><p style=\"float: right; padding-right: 1rem;\">Rated:" + imdbEntity.Rated + "</li>";
                                html += "</ul>";

                                html += "\t\t<a class=\"info link1 text-small\" href=\"https://www.imdb.com/title/" + imdbEntity.imdbID + "\" style=\"margin-right: 1rem\">Link to IMDB</a>";
                                phMovies.Controls.Add(new Literal { Text = html });

                                LinkButton btnAddMovie = new LinkButton();
                                btnAddMovie.ID = "addMovie" + imdbEntity.imdbID;
                                btnAddMovie.Click += new EventHandler(btnRemove_Click);
                                btnAddMovie.CssClass = "info link2 text-small";
                                btnAddMovie.Text = "Remove Movie";
                                btnAddMovie.CommandName = "removeMovie";
                                btnAddMovie.CommandArgument = imdbEntity.imdbID;
                                phMovies.Controls.Add(btnAddMovie);

                                html = "";
                                html += "\t</div>";
                                html += "</div>\n";
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
                } else {
                    lblError.Text = "You have not added any movies.";
                }
      

                
            } catch(Exception)
            {
                lblError.Text = "Unable to get your movies.";
            }

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;

            switch (btn.CommandName)
            {
                case "removeMovie":
                    try
                    {
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
                    } catch(Exception)
                    {
                        lblError.Text = "Unable to remove movie.";
                    }

                    break;
            }

        }
    }
}