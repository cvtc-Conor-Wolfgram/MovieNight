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


        }
    }
}