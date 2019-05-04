using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        User currentUser;
        List<Group> groups = new List<Group>();
        private List<User> members = new List<User>();
        private MovieNightContext db = new MovieNightContext();


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


            groups = db.groups.SqlQuery("Select [Group].groupID, groupName, groupCode, ownerID " +
                "FROM [Group] INNER JOIN UserGroup on UserGroup.groupID = [Group].groupID " +
                "WHERE UserGroup.userID = " + currentUser.userID).ToList<Group>();

            String html= "";
            foreach(Group group in groups)
            {
                int currentGroupID = group.groupID;

                members = db.users.SqlQuery("SELECT * " +
                    "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                    "WHERE [UserGroup].groupID = " + currentGroupID +
                    " ORDER BY [UserGroup].joinNumber").ToList<User>();

                html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">\n";
                html += "\t<a href='Group.aspx?groupID=" + group.groupID + "'>" + group.groupName + "</a>\n";
                html += "\t<span class=\"badge badge-primary badge - pill\">" + members.Count()  + "</span>";
                html += "</li>\n";
            }

            phGroupList.Controls.Add(new Literal { Text = html });

        }
    }
}