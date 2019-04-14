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
        protected void Page_Load(object sender, EventArgs e)
        {
            var localDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
            
            txtDateTime.Text = localDateTime;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            DateTime dateTime;

            dateTime = DateTime.Parse(txtDateTime.Text);
            lblTest.Text = dateTime.ToString();

            Event newEvent = new Event();

            newEvent.eventName = txtEName.Text;
            newEvent.eventLocation = txtLocation.Text;
            newEvent.eventDateTime = DateTime.Parse(txtDateTime.Text);
            newEvent.numTickets = int.Parse(txtTickets.Text);

            MovieNightContext context = new MovieNightContext();
            context.events.Add(newEvent);
            context.SaveChanges();

            Response.Redirect("Default.aspx");


        }
    }
}