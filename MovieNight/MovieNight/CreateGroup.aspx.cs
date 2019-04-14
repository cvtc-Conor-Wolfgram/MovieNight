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
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        



        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Group group = new Group();

            group.groupName = txtGroupName.Text;
            group.groupCode = new Random().Next(10000, 100000);


            Response.Redirect("Default.aspx");
        }
    }
}