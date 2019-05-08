using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class CreateEvent : System.Web.UI.Page
    {

        private User currentUser;
        private Group pageGroup = new Group();

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

            } else //Not Post Back
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
            } else
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
                    } else
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
    }
}