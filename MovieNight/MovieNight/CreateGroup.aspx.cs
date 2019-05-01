using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userAccount"] != null)
            {
                currentUser = (User)Session["userAccount"];
            }
            else
            {
                Response.Redirect("CreateAccount.aspx");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        



        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Group group = new Group();

            group.groupName = txtGroupName.Text;
            group.groupCode = new Random().Next(10000, 100000);

            MovieNightContext context = new MovieNightContext();
            context.groups.Add(group);
            context.SaveChanges();

            UserGroup newUserGroup = new UserGroup();
            newUserGroup.userID = currentUser.userID;
            newUserGroup.groupID = group.groupID;
            newUserGroup.turnToPick = 1;
            newUserGroup.joinNumber = 1;
            context.userGroup.Add(newUserGroup);
            context.SaveChanges();

            Response.Redirect("Default.aspx");
        }
    }
}