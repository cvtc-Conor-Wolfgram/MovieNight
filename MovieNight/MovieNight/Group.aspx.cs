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

        List<User> members = new List<User>();
        User picker = new User();
        //Group pageGroup = new Group();
        private MovieNightContext db = new MovieNightContext();
        User currentUser;
        //List<Movie> moviesSuggested = new List<Movie>();
        List<Movie> nextMoviesAvalible = new List<Movie>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];
            }
            else
            {
                Response.Redirect("CreateAccount.aspx");
            }


            if (Request.QueryString["groupID"] != null) {

                int currentGroupID = Convert.ToInt16(Request.QueryString["groupID"]);
                //Getting page and owner Info
                Group pageGroup = db.groups.SqlQuery("Select * " +
                    "FROM [Group] WHERE groupID=" + currentGroupID).FirstOrDefault();

                groupName.InnerText = pageGroup.groupName;
                //ownerName.InnerText = "Group Owner: " + pageGroup.ownerName.ToString();


                //Setting members list and who's turn it is to pick
                members = db.users.SqlQuery("SELECT [User].userID, [User].userName, [User].fName, [User].lName, [User].passwordHash, [User].email " +
                    "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                    "WHERE [UserGroup].groupID = "+ currentGroupID +
                    " ORDER BY [UserGroup].joinNumber").ToList<User>();

                String html = "<h4>Members:</h4>";
                foreach(User member in members)
                {
                    html += "<li>" + member.fName + " " + member.lName + "</li>";



                    if(db.userGroup.Find(member.userID, currentGroupID).turnToPick == 1)
                    {
                        picker = member;
                        pickerName.InnerText = "The current picker is " + picker.fName + " " + picker.lName;
                    }
                }
                phMembers.Controls.Clear();
                phMembers.Controls.Add(new Literal { Text = html });

                displayMoviesList(picker);
                
            } else
            {
                Response.Redirect("Group.aspx?groupID=1");
            }

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
                        pickerName.InnerText = "The current picker is " + picker.fName + " " + picker.lName;
                        displayMoviesList(picker);

                    }
                    catch (Exception)
                    {

                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 0 WHERE userID = " + members[i].userID + "and groupID = " + currentGroupID);
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 1 WHERE userID = " + members[0].userID + "and groupID = " + currentGroupID);
                        picker = members[0];
                        pickerName.InnerText = "The current picker is " + picker.fName + " " + picker.lName;
                        displayMoviesList(picker);
                    }
                    break;

                }
            }
        }


        protected void displayMoviesList(User picker)
        {
            //List of current movies to be picked
            nextMoviesAvalible = db.movies.SqlQuery("SELECT Movie.movieID, Movie.omdbCode FROM Movie INNER JOIN UserMovie on Movie.movieID = UserMovie.movieID WHERE userID = " + picker.userID).ToList<Movie>();

            String html = "";
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
                        html += "<li style='display: inline-block'>\n";
                        html += "\t<img src='"+ imdbEntity.Poster +"' width='150px'>\n";
                        html += "\t<p>"+ imdbEntity.Title + "</p>";
                        html += "</li>\n";

                    }
                    else
                    {
                        html += "<li>\n";
                        html += "\t<p>Movie not Found!!!</p>\n";
                        html += "</li>\n";

                    }


                }




                
            }

            phNextMovies.Controls.Clear();
            phNextMovies.Controls.Add(new Literal { Text = html });
        }

    }
}