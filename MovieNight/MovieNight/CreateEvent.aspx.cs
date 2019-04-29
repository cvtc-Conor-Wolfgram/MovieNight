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

            //if (ViewState["Date"] != null)
            //{
            //    txtDateTime.Text = ViewState["Date"].ToString();
            //} else
            //{
            //    txtDateTime.Text = localDateTime;
            //}
            txtDateTime.Text = localDateTime;

            if (ViewState["Date"] != null)
            {
                txtDateTime.Text = ViewState["Date"].ToString();
            }
            

            lblTickets.Visible = false;
            txtTickets.Visible = false;
            rvTickets.Visible = false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            DateTime dateTime;

            dateTime = DateTime.Parse(txtDateTime.Text);
            lblTest.Text = dateTime.ToString();

            Event newEvent = new Event();

            newEvent.eventName = txtEName.Text;
            newEvent.eventLocation = txtLocation.Text;
            newEvent.eventTime = DateTime.Parse(txtDateTime.Text);

            if (cbTheater.Checked == true)
            {
                newEvent.ticketsBought = 1;
                newEvent.numTickets = int.Parse(txtTickets.Text);
            } else
            {
                newEvent.ticketsBought = 0;
            }

            

            MovieNightContext context = new MovieNightContext();
            context.events.Add(newEvent);
            context.SaveChanges();

            Response.Redirect("Default.aspx");


        }

        protected void cbTheater_CheckedChanged(object sender, EventArgs e)
        {
            var dateTimeHolder = txtDateTime.Text;

            ViewState["Date"] = txtDateTime.Text;

            if (cbTheater.Checked == true)
            {
                txtDateTime.Text = ViewState["Date"].ToString();
                lblTickets.Visible = true;
                txtTickets.Visible = true;
                rvTickets.Visible = true;

            }
            else
            {
                txtDateTime.Text = ViewState["Date"].ToString();
                lblTickets.Visible = false;
                txtTickets.Visible = false;
                rvTickets.Visible = false;
            }
        }
    }
}