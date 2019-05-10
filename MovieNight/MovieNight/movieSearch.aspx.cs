using MovieNight.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MovieNight
{

    public partial class movieSearch : System.Web.UI.Page
    {
        private MovieNightContext db = new MovieNightContext();
        User currentUser;

        // Buttons need to be created in the Page_Init function if you want their click event handlers to have any effect.  Thus, we redirect the user to the same page(with an extra url parameter) with the search click handler. We then check for the parameter to see if we need to call the api and create the new html to display movies.
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

            if (Request.QueryString["title"] != null)
            {
                using (WebClient wc = new WebClient())
                {
                    String url = "http://www.omdbapi.com/?&apikey=b9bb3ece&s=" + Request.QueryString["title"];
                    var json = wc.DownloadString(url);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    ImdbEntityArray imdbEntityArray = new ImdbEntityArray();
                    imdbEntityArray = oJS.Deserialize<ImdbEntityArray>(json);
                    if (imdbEntityArray.Search != null)
                    {
                        String html = "";
                        phMovieResults.Controls.Clear();
                        html += "<div class=\"row\">\n";
                        phMovieResults.Controls.Add(new Literal { Text = html });

                        foreach (ImdbEntity movie in imdbEntityArray.Search)
                        {
                            String url2 = "http://www.omdbapi.com/?&apikey=b9bb3ece&i=" + movie.imdbID;
                            var json2 = wc.DownloadString(url2);
                            JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                            ImdbEntity imdbEntity = new ImdbEntity();
                            imdbEntity = oJS2.Deserialize<ImdbEntity>(json2);

                            html = "";
                            html += "<div class=\"col-lg-4\" style=\" margin-top: 1rem; height: 450px; width: 314px\">\n";
                            html += "\t<div class=\"hovereffect\" style=\"height: 450px; width: 314px\">\n";
                           
                            if (movie.Poster == "N/A")
                            {
                                
                                html += "\t\t\t<img height=\"450px\" width=\"314px\" class=\"img - responsive\"  src='images/defaultPoster.jpg'>\n";


                            }
                            else
                            {
                                
                                html += "\t\t<img height=\"450px\" width= \"314px\"  class=\"img - responsive\" src='" + movie.Poster + "'>\n";
                 
                            }

                            html += "<div class=\"overlay\">";
                            html += "\t\t<h2>" + movie.Title + " (" + movie.Year + ")</h2>";
                            html += "<p class=\"text-muted\" style=\"text-align: left; padding: 1rem;\">" + imdbEntity.Plot + "</p>";
                            html += "<ul>";
                            html += "<li><p style=\"float: left; padding-left: 1rem;\">Runtime: " + imdbEntity.Runtime + "</p><p style=\"float: right; padding-right: 1rem;\">Rated:" + imdbEntity.Rated + "</li>";
                            html += "</ul>";

                            html += "\t\t<a class=\"info link1\" href=\"https://www.imdb.com/title/" + movie.imdbID + "\" style=\"margin-right: 1rem\">Link to IMDB</a>";
                            phMovieResults.Controls.Add(new Literal { Text = html });

                            LinkButton btnAddMovie = new LinkButton();
                            btnAddMovie.Click += new EventHandler(btnAddMovie_Click);
                            btnAddMovie.CssClass = "info link2";
                            btnAddMovie.Text = "Add Movie";
                            btnAddMovie.CommandName = "addMovie";
                            btnAddMovie.CommandArgument = movie.imdbID;

                            phMovieResults.Controls.Add(btnAddMovie);

                            html = "";
                            html += "\t</div>";
                            html += "</div>\n";
                            html += "</div>";
                            phMovieResults.Controls.Add(new Literal { Text = html });
                        }


                        html = "";
                        html += "</div>\n";
                        phMovieResults.Controls.Add(new Literal { Text = html });

                    }
                    else
                    {
                        String html = "";
                        html += "<li>\n";
                        html += "\t<p>Movie not Found!!!</p>\n";
                        html += "</li>\n";
                        phMovieResults.Controls.Add(new Literal { Text = html });

                    }
                }
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("movieSearch.aspx?title=" + txtSearch.Text);


            
        }

        protected void btnAddMovie_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var date = DateTime.Now;
            switch(btn.CommandName)
            {
                case "addMovie":
                    //SQL to add movie goes here
                    Movie newMovie = new Movie();
                    newMovie = db.movies.SqlQuery("SELECT * FROM Movie WHERE omdbCode= '" + btn.CommandArgument + "'").FirstOrDefault();

                    if (newMovie == null)
                    {
                        db.Database.ExecuteSqlCommand("INSERT INTO Movie (omdbCode) VALUES ('" + btn.CommandArgument + "')");
                        newMovie = db.movies.SqlQuery("SELECT * FROM Movie WHERE omdbCode= '" + btn.CommandArgument + "'").FirstOrDefault();

                    }

                    UserMovie newUserMovie = new UserMovie();

                    newUserMovie.userID = currentUser.userID;
                    newUserMovie.movieID = newMovie.movieID;
                    newUserMovie.dateAdded = DateTime.Now;

                    MovieNightContext context = new MovieNightContext();
                    context.userMovie.Add(newUserMovie);
                    context.SaveChanges();

                    //db.Database.ExecuteSqlCommand("INSERT INTO UserMovie (userID, movieID, dateAdded) VALUES (" + currentUser.userID + "," + newMovie.movieID + "," + Convert.ToDateTime(DateTime.Now.ToString()) +")");
                    //lblResult.Text = "Movie has been added.";                   

                    break;
            }

        }
    }
}