using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private MovieNightContext db = new MovieNightContext();
        private User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];
            }
            else
            {
                Session["redirectTo"] = "ChangePassword.aspx";
                Response.Redirect("CreateAccount.aspx");
            }


        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            var oldPass = txtOldPass.Text.ToString();

            var newPass = txtNewPass.Text;




            var email = currentUser.email;

            var userId = currentUser.userID;




            var query = db.users.SqlQuery("Select * from [User] Where email = '" + email + "'").First();

            string savedPasswordHash = query.passwordHash;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(oldPass, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            int match = 1;
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    match = 0;
            if (match == 1)
            {

                byte[] salt2;

                new RNGCryptoServiceProvider().GetBytes(salt2 = new byte[16]);

                var pbkdf22 = new Rfc2898DeriveBytes(newPass, salt2, 10000);

                byte[] hash2 = pbkdf22.GetBytes(20);
                byte[] hashBytes2 = new byte[36];

                Array.Copy(salt2, 0, hashBytes2, 0, 16);
                Array.Copy(hash2, 0, hashBytes2, 16, 20);

                string savedPasswordHash2 = Convert.ToBase64String(hashBytes2);



                db.Database.ExecuteSqlCommand("Update [User] SET passwordHash = ('" + savedPasswordHash2 + "') Where (userID = " + userId + ")");
                db.SaveChanges();
                

            }
            else
            {
                passCompare.Visible = true;
             
            }
        }
    }
}