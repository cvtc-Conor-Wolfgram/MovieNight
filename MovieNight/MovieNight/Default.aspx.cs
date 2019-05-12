using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];
                Response.Redirect("accountInfo.aspx");


            }
            else
            {
                Session["redirectTo"] = "accountInfo.aspx";

            }
        }


    }
}