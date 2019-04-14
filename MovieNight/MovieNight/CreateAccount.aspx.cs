using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string userName = txtUserName.Text;
            //string fName = txtFName.Text;
            //string lName = txtLName.Text;
            //string email = txtUserEmail.Text;
            //string password = txtUserPass.Text;

            User user = new User();

            user.userName = txtUserName.Text;
            user.fName = txtFName.Text;
            user.lName = txtLName.Text;
            user.email = txtUserEmail.Text;
            user.password = txtUserPass.Text;

            Session.Add("userAccount", user);

            MovieNightContext context= new MovieNightContext();
            context.User.Add(user);
            context.SaveChanges();

            Response.Redirect("Default.aspx");






        }
    }
}