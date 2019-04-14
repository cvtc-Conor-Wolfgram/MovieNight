using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    public class Group
    {
        public int groupID { get; set; }
        public String groupName { get; set; }
        public int groupCode { get; set; }
        public int ownerID { get; set; }
        public String ownerName { get; set; }
        public List<User> groupMemebers { get; set; }
        

        public Group()
        {

        }

        public int groupSize()
        {
            return this.groupMemebers.Count - 1;
        }
    }
}