using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieNight.Models;

namespace MovieNight
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        private User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];
                createButton.Text = "Logout";
                

            }
            else
            {
                createButton.Text = "Sign In/Sign Up";
                
            }

        }

        protected void createButtonClick(object sender, EventArgs e)
        {
            if (createButton.Text == "Logout")
            {
                Session["userAccount"] = null;
                Response.Redirect("Default.aspx");

            }
            else
            {
                createButton.Text = "Sign In/Sign Up";
                Response.Redirect("CreateAccount.aspx");
            }

        }

        

    }
}