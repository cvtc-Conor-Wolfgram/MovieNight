using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNight
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        List<User> members = new List<User>();
        User picker = new User();
        Group pageGroup = new Group();
        private MovieNightContext db = new MovieNightContext();
        //List<Movie> moviesSuggested = new List<Movie>();
        //List<Movie> nextMoviesAvalible = new List<Movie>();


        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting page and owner Info
            pageGroup = db.Database.SqlQuery<Group>("Select groupID, groupName, groupCode, ownerID, Concat(fName, lName) as ownerName " +
                "from [Group] inner join [User] on [Group].ownerID = [User].userID " +
                "Where groupID = 1").FirstOrDefault();

            groupName.InnerText = pageGroup.groupName;
            ownerName.InnerText = "Group Owner: " + pageGroup.ownerName.ToString();


            //Setting members list and who's turn it is to pick
            members = db.users.SqlQuery("SELECT [User].userID, [User].userName, [User].fName, [User].lName, [User].password, [User].email," +
                " joinNumber, turnToPick " +
                "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                "WHERE [UserGroup].groupID = 1" +
                "ORDER BY [UserGroup].joinNumber").ToList<User>();

            foreach(User member in members)
            {
                if(member.turnToPick == 1)
                {
                    picker = member;
                    pickerName.InnerText = "The current picker is " + picker.fName + " " + picker.lName;
                }
            }

        }


        protected void finishedMovie_Click(object sender, EventArgs e)
        {

            //Changes who's turn it is to pick after a button click
            for (int i = 0; i < members.Count; i++) //For all the members
            {
                if (members[i].turnToPick == 1) //Find the person who is currently picking
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 0 WHERE userID = " + members[i].userID);
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 1 WHERE userID = " + members[i + 1].userID);
                        picker = members[i + 1];
                        pickerName.InnerText = "The current picker is " + picker.fName + " " + picker.lName;
                    }
                    catch (Exception)
                    {

                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 0 WHERE userID = " + members[i].userID);
                        db.Database.ExecuteSqlCommand("UPDATE UserGroup SET turnToPick = 1 WHERE userID = " + members[0].userID);
                        picker = members[0];
                        pickerName.InnerText = "The current picker is " + picker.fName + " " + picker.lName;
                    }
                    break;

                }
            }
        }

    }
}