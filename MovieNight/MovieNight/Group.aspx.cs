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

        System.Data.SqlClient.SqlConnection conn;
        System.Data.SqlClient.SqlCommand cmd;
        String queryStr;
        List<User> members = new List<User>();
        List<Movie> moviesSuggested = new List<Movie>();
        List<Movie> nextMoviesAvalible = new List<Movie>();
        Group pageGroup = new Group();

        protected void Page_Load(object sender, EventArgs e)
        {

            conn = connectionString();
            conn.Open();

            queryStr = "Select groupID, groupName, groupCode, Concat(fName, lName) as ownerName from [Group] inner join [User] on [Group].ownerID = [User].userID  where groupID = 1;";

            cmd = new System.Data.SqlClient.SqlCommand(queryStr, conn);
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                pageGroup.groupID = (int)reader["groupID"];
                pageGroup.groupName = (String)reader["groupName"];
                pageGroup.groupCode = (int)reader["groupCode"];
                pageGroup.ownerName = (String)reader["ownerName"];
            }

            groupName.InnerText = pageGroup.groupName;
            ownerName.InnerText = pageGroup.ownerName.ToString();

            conn.Close();




        }

        private System.Data.SqlClient.SqlConnection connectionString()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MovieNightContext"].ToString();

            return new System.Data.SqlClient.SqlConnection(connString);



        }

        protected void finishedMovie_Click(object sender, EventArgs e)
        {

            conn = connectionString();
            conn.Open();

            queryStr = "SELECT [User].userID, joinNumber, turnToPick " +
                    "FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID " +
                    "WHERE [UserGroup].groupID = 1 " +
                    "ORDER BY [UserGroup].joinNumber";

            cmd = new System.Data.SqlClient.SqlCommand(queryStr, conn);
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User member = new User();
                member.userID = (int)reader["userID"];
                member.joinNumber = (int)reader["joinNumber"];
                member.turnToPick = (int)reader["turnToPick"];

                members.Add(member);
            }
            cmd.Dispose();
            reader.Close();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].turnToPick == 1)
                {
                    try
                    {
                        queryStr = "UPDATE [UserGroup] SET turnToPick = 0 WHERE userID = " + members[i].userID + ";";
                        queryStr += "UPDATE [UserGroup] SET turnToPick = 1 WHERE userID = " + members[i + 1].userID + ";";
                        
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        queryStr = "UPDATE [UserGroup] SET turnToPick = 0 WHERE userID = " + members[i].userID + ";";
                        queryStr += "UPDATE [UserGroup] SET turnToPick = 1 WHERE userID = " + members[0].userID + ";";
                    }
                    cmd = new System.Data.SqlClient.SqlCommand(queryStr, conn);
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    ListView1.DataBind();
                    break;

                }
            }



            conn.Close();
        }
    }
}