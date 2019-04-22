using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MovieNight
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private MovieNightContext db = new MovieNightContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataView dvSql = (DataView)UserConnection.Select(DataSourceSelectArguments.Empty);

            foreach (DataRowView drvSql in dvSql)
            {
                nameLbl.Text = drvSql["fName"].ToString();
                userNameLbl.Text = drvSql["UserName"].ToString();
                emailLbl.Text = drvSql["email"].ToString();
            }

        }

        protected void btnJoinGroup_Click(object sender, EventArgs e)
        {
            if (db.Database.SqlQuery<User>("SELECT * FROM [User] INNER JOIN Usergroup ON [User].userID = Usergroup.userID INNER JOIN [Group] on Usergroup.groupID = [Group].groupID WHERE [User].userID = 4 AND [Group].groupCode = " + txtGroupCode.Text).FirstOrDefault() == null)
            {
                Group group = new Group();
                group = db.Database.SqlQuery<Group>("SELECT *, CONCAT(fName, lName) as ownerName FROM [GROUP] INNER JOIN [User] ON [User].userID = [Group].ownerID  WHERE [GROUP].groupCode = " + txtGroupCode.Text).FirstOrDefault();

                int lastUserJoinNum = db.Database.SqlQuery<int>("SELECT joinNumber FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID WHERE [UserGroup].groupID = " + group.groupID + "ORDER BY [UserGroup].joinNumber DESC").FirstOrDefault();

                lastUserJoinNum++;

                db.Database.ExecuteSqlCommand("INSERT INTO UserGroup (userID, groupID, joinNumber, turnToPick) VALUES ('4', '" + group.groupID + "', '" + lastUserJoinNum + "', '0')");

            } else
            {
                lblJoinResponse.Text = "You are already a part of this group.";
            }
        }
    }
}