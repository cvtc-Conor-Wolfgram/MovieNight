using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
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
        private Event currentEvent = new Event();
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
                try
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
                        ownerName.InnerText = "Leader: " + groupOwner.fName + " " + groupOwner.lName;
                    }
                    else
                    {
                        ownerName.InnerText = "Unable to Retrieve Owner.";
                    }

                    groupCode.InnerText = "Group Code: " + pageGroup.groupCode.ToString();

                    try
                    {
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
                                lblPicker.InnerText = "Picker: " + picker.fName + " " + picker.lName;

                            }
                            else
                            {
                                html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">" + member.fName + " " + member.lName + "</li>";
                            }
                        }
                        phMembers.Controls.Clear();
                        phMembers.Controls.Add(new Literal { Text = html });
                    } catch (Exception)
                    {
                        lblError.Text = "Unable to get members.";
                    }


                    try
                    {
                        //Setting up event
                        currentEvent = db.events.SqlQuery("SELECT * FROM Event WHERE groupID=" + currentGroupID).FirstOrDefault();

                        if (currentEvent != null)
                        {
                            lblEventInfo.InnerText = "Meet at " + currentEvent.eventLocation + " on " + currentEvent.eventTime.Date.ToShortDateString() + " at " + currentEvent.eventTime.ToShortTimeString();
                            displayMovie();

                            if (currentUser.userID == picker.userID || currentUser.userID == groupOwner.userID)
                            {
                                finishedMovie.Visible = true;
                            }
                            else
                            {
                                finishedMovie.Visible = false;

                            }

                            btnCreateEvent.Visible = false;

                        }
                        else
                        {

                            if (currentUser.userID == picker.userID || currentUser.userID == groupOwner.userID)
                            {
                                btnCreateEvent.Visible = true;
                                finishedMovie.Visible = true;
                                finishedMovie.Text = "Abdicate Picker Turn";
                            }
                            else
                            {
                                btnCreateEvent.Visible = false;
                                finishedMovie.Visible = false;
                            }

                        }
                    } catch (Exception)
                    {
                        lblError.Text = "Unable to get event.";
                    }

                } catch (Exception)
                {
                    lblError.Text = "Unable to get group.";
                }
                

            }
            else
            {
                Response.Redirect("accountinfo.aspx");
            }


        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void finishedMovie_Click(object sender, EventArgs e)
        {
            int currentGroupID = Convert.ToInt16(Request.QueryString["groupID"]);

            if (currentEvent != null)
            {
                try
                {
                    db.events.Remove(currentEvent);
                    db.SaveChanges();
                } catch (Exception)
                {
                    lblError.Text = "Unable to remove event.";
                }

                removeUserMovie(picker, currentEvent.movieID);
            }
            try
            {
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


                        }
                        catch (Exception)
                        {

                            db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 0 WHERE userID = " + members[i].userID + "and groupID = " + currentGroupID);
                            db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 1 WHERE userID = " + members[0].userID + "and groupID = " + currentGroupID);
                            picker = members[0];

                        }

                        break;

                    }
                }

                Response.Redirect("Group.aspx?groupID=" + currentGroupID);

            } catch (Exception)
            {
                lblError.Text = "Unable to progress picker rotation.";
            }
        }



        protected void displayMovie()
        {
            try {
                Movie selectedMovie = db.movies.SqlQuery("SELECT * FROM Movie WHERE movieID=" + currentEvent.movieID).FirstOrDefault();
                var html = "";
                phNextMovies.Controls.Clear();
                string url = "http://www.omdbapi.com/?&apikey=b9bb3ece&i=" + selectedMovie.omdbCode;
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
                        html += "</div>";
                        html += "</div>";

                        phNextMovies.Controls.Add(new Literal { Text = html });
                    }
                }

            } catch (Exception)
            {
                lblError.Text = "Unable to display movie";
            }

        }

        protected void createEvent_Click(object sender, EventArgs e)
        {
            Session.Add("group", pageGroup);
            Session.Add("picker", picker);


            Response.Redirect("createEvent.aspx");
        }

        protected void removeUserMovie(User picker, int movieToRemoveID)
        {
            try
            {
                db.Database.ExecuteSqlCommand("DELETE FROM [UserMovie] WHERE userID = " + picker.userID + " AND movieID = " + movieToRemoveID);

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                db.SaveChanges();

                foreach (var entity in db.ChangeTracker.Entries())
                {
                    entity.Reload();
                }
                db.Database.ExecuteSqlCommand("DELETE FROM [UserMovie] WHERE userID = " + picker.userID + " AND movieID = " + movieToRemoveID);
                db.SaveChanges();

            } catch (Exception)
            {
                lblError.Text = "Unable to remove event.";
            }


        }

    }
}