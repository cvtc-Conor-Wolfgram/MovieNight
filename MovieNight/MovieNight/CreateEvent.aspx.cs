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
    public partial class CreateEvent : System.Web.UI.Page
    {

        private User currentUser;
        private Group pageGroup = new Group();
        private MovieNightContext db = new MovieNightContext();
        private List<Movie> nextMoviesAvalible = new List<Movie>();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];

            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            displayMoviesList(currentUser);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            welcomeText.InnerText = "Welcome " + currentUser.userName.TrimEnd(' ', '\t') + ", please create a new event.";


            DateTime currentDate = DateTime.Now;




            lblTickets.ForeColor = System.Drawing.Color.Gray;
            txtTickets.Enabled = false;
            rvTickets.Enabled = false;

            if (IsPostBack) //Post back rollover of date/time
            {
                if (Request[txtDate.UniqueID] != null)
                {
                    if (Request[txtDate.UniqueID].Length > 0)
                    {
                        txtDate.Text = Request[txtDate.UniqueID];
                    }
                }

                if (Request[txtTime.UniqueID] != null)
                {
                    if (Request[txtTime.UniqueID].Length > 0)
                    {
                        txtTime.Text = Request[txtTime.UniqueID];
                    }
                }

            }
            else //Not Post Back
            {
                txtDate.Text = currentDate.ToString("yyyy-MM-dd");
                txtTime.Text = currentDate.AddHours(1).Hour.ToString() + ":00";
            }
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            DateTime dateTime;

            // Format: "yyyy-MM-dd HH:mm:ss"
            dateTime = DateTime.Parse(txtDate.Text + " " + txtTime.Text + ":00");

            //Check for Date Time being within valid range

            //

            //Int is < 0 if DateTime.now is earlier than dateTime, 0 if equal, and > 0 if later
            int dateComp = DateTime.Compare(DateTime.Now, dateTime);

            //Int is < 0 if DateTime.now(plus 2 weeks) is earlier than dateTime, 0 if equal, and > 0 if later
            int dateFuture = DateTime.Compare(DateTime.Now.AddDays(15), dateTime);

            //If date time is later than currentDateTime and is before currentDateTime(+15 days)
            if (dateComp >= 0 || dateFuture <= 0)
            {

                lblDateTimeError.Text = "Enter a date between now and 2 weeks";
                lblDateTimeError.Visible = true;
            }
            else
            {

                //lblDateTimeError.Visible = false;  // error display test

                Event newEvent = new Event();

                newEvent.eventName = txtEName.Text;
                newEvent.eventLocation = txtLocation.Text;
                newEvent.eventTime = dateTime;

                if (cbTheater.Checked == true)
                {

                    int tickets; //number of tickets bought
                    bool ticketsBought = int.TryParse(txtTickets.Text, out tickets);

                    if (ticketsBought == true) // prevent int error
                    {
                        newEvent.numTickets = tickets;
                    }
                    else
                    {
                        newEvent.ticketsBought = 1;
                    }

                }
                else
                {
                    newEvent.ticketsBought = 0;
                }

                newEvent.eventOwner = currentUser.userID;



                MovieNightContext context = new MovieNightContext();
                context.events.Add(newEvent);
                context.SaveChanges();

                Response.Redirect("Default.aspx");
            }




        }

        protected void cbTheater_CheckedChanged(object sender, EventArgs e)
        {


            if (cbTheater.Checked == true)
            {

                lblTickets.ForeColor = System.Drawing.Color.White;
                txtTickets.Enabled = true;
                rvTickets.Enabled = true;

            }
            else
            {


                lblTickets.ForeColor = System.Drawing.Color.Gray;
                txtTickets.Enabled = false;
                rvTickets.Enabled = false;
            }
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

                        Button btnAddMovie = new Button();
                        btnAddMovie.ID = "addMovie" + imdbEntity.imdbID;
                        btnAddMovie.Click += new EventHandler(btnRemove_Click);
                        btnAddMovie.CssClass = "btn btn-primary";
                        btnAddMovie.Text = "Remove Movie";
                        btnAddMovie.CommandName = "removeMovie";
                        btnAddMovie.CommandArgument = imdbEntity.imdbID;
                        phNextMovies.Controls.Add(btnAddMovie);
         

                    html = "";
                    html += "</div>";
                    html += "</div>";

                    phNextMovies.Controls.Add(new Literal { Text = html });
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
