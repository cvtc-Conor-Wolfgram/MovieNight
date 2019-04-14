using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
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