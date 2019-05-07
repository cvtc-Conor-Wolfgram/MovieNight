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
        List<Group> yourGroups = new List<Group>();
        List<Group> notYourGroups = new List<Group>();
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

            groups = db.groups.SqlQuery("Select * From [Group]").ToList<Group>();

            yourGroups = db.groups.SqlQuery("Select Distinct [Group].groupID, groupName, groupCode, ownerID " +
                "FROM [Group] INNER JOIN UserGroup on UserGroup.groupID = [Group].groupID " +
                "WHERE UserGroup.userID = " + currentUser.userID).ToList<Group>();

            notYourGroups = groups.Except(yourGroups).ToList<Group>();

            String html= "";

            foreach (Group group in notYourGroups)
            {

                int currentGroupID = group.groupID;

                members = db.users.SqlQuery("SELECT * " +
                    "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                    "WHERE [UserGroup].groupID = " + currentGroupID +
                    " ORDER BY [UserGroup].joinNumber").ToList<User>();

                html += "<li class=\"list-group-item d-flex justify-content-between align-items-center\">\n";
                html += "\t<a href='Group.aspx?groupID=" + group.groupID + "'>" + group.groupName + "</a>\n";

                phGroupList.Controls.Add(new Literal { Text = html });

                Button btnAddMovie = new Button();
                btnAddMovie.Click += new EventHandler(btnJoinGroup_Click);
                btnAddMovie.CssClass = "btn btn-primary";
                btnAddMovie.Text = "Join Group";
                btnAddMovie.CommandName = "joinGroup";
                btnAddMovie.CommandArgument = group.groupID.ToString();

                phGroupList.Controls.Add(btnAddMovie);


                html = "";
                html += "</li>\n";
                phGroupList.Controls.Add(new Literal { Text = html });

                
            }

            

        }

        protected void btnJoinGroup_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
              
             Group group = new Group();
                group = db.Database.SqlQuery<Group>("SELECT * FROM [GROUP] WHERE [GROUP].groupID = " + btn.CommandArgument).FirstOrDefault();

                    int lastUserJoinNum = db.Database.SqlQuery<int>("SELECT joinNumber FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID WHERE [UserGroup].groupID = " + btn.CommandArgument + "ORDER BY [UserGroup].joinNumber DESC").FirstOrDefault();

                    lastUserJoinNum++;

                    db.Database.ExecuteSqlCommand("INSERT INTO UserGroup (userID, groupID, joinNumber, turnToPick) VALUES (" + currentUser.userID + ", '" + btn.CommandArgument + "', '" + lastUserJoinNum + "', '0')");

                    UserGroup newUserGroup = new UserGroup();
                    newUserGroup.userID = currentUser.userID;
                    newUserGroup.groupID = group.groupID;
                    newUserGroup.joinNumber = lastUserJoinNum;
                    newUserGroup.turnToPick = 0;
                    db.userGroup.Add(newUserGroup);


            Response.Redirect("Group.aspx?groupID=" + btn.CommandArgument + "");
             



                     
        }
    }
}