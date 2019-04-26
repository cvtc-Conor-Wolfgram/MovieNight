using MovieNight.Models;
using System;
using System.Collections.Generic;
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
        private MovieNightContext db = new MovieNightContext();


        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["userAccount"] != null)
            {
               // currentUser = (User)Session["userAccount"];
            }
            else
            {
                Response.Redirect("CreateAccount.aspx");
            }


            groups = db.groups.SqlQuery("Select [Group].groupID, groupName, groupCode, ownerID, Concat(fName, lName) as ownerName " +
                "from [Group] inner join [User] on [Group].ownerID = [User].userID INNER JOIN UserGroup on UserGroup.groupID = [Group].groupID " +
                "Where UserGroup.userID = 4").ToList<Group>();

            String html= "";
            foreach(Group group in groups)
            {
                html += "<li>\n";
                html += "\t<a href='Group.aspx?groupID=" + group.groupID + "'>" + group.groupName + "</a>\n";
                html += "</li>\n";
            }

            phGroupList.Controls.Add(new Literal { Text = html });
        }
    }
}