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

        // Buttons need to be created in the Page_Init function if you want their click event handlers to have any effect.  Thus, we redirect the user to the same page(with an extra url parameter) with the search click handler. We then check for the parameter to see if we need to call the api and create the new html to display movies.
        protected void Page_Init(object sender, EventArgs e)
        {
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
                            html = "";
                            html += "<div class=\"col - md - 3\" style=\"padding: 1rem;\">\n";
                            html += "\t<div class=\"well text-center\">\n";
                            html += "\t\t<img height=\"420px\" src='" + movie.Poster + "'>\n";
                            html += "\t\t<h5>" + movie.Title + " (" + movie.Year + ")</h5>";
                            html += "\t\t<a class=\"btn btn-primary\" href=\"https://www.imdb.com/title/" + movie.imdbID + "\">Link to IMDB</a>";
                            phMovieResults.Controls.Add(new Literal { Text = html });

                            Button btnAddMovie = new Button();
                            btnAddMovie.ID = "addMovie" + movie.imdbID;
                            btnAddMovie.Click += new EventHandler(btnAddMovie_Click);
                            btnAddMovie.CssClass = "btn btn-primary";
                            btnAddMovie.Text = "Add Movie";
                            btnAddMovie.CommandName = "addMovie";
                            btnAddMovie.CommandArgument = movie.imdbID;

                            phMovieResults.Controls.Add(btnAddMovie);

                            html = "";
                            html += "\t</div>";
                            html += "</div>\n";
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
            var btn = (Button)sender;

            switch(btn.CommandName)
            {
                case "addMovie":
                    //SQL to add movie goes here

                    break;
            }

        }
    }
}