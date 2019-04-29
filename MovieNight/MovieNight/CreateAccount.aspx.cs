using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace MovieNight
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        private MovieNightContext db = new MovieNightContext();
         
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
            context.users.Add(user);
            context.SaveChanges();

        

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            var email = txtActiveEmail.Text.ToString();

            var pass = txtActivePass.Text;
            Session["userAccount"] = email;


                DataView dvSql = (DataView)UserConnection.Select(DataSourceSelectArguments.Empty);

            

            if (dvSql.Count == 0)
                emailCompare.Visible = true;
            else
               
            

                    Response.Redirect("accountinfo.aspx");
                
            
            



        }
    }
}