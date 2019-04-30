using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key, Column(Order = 0)]
        public int userID { get; set; }
        [Key, Column(Order = 1)]
        public int groupID { get; set; }
        public int joinNumber { get; set; }
        public int turnToPick { get; set; }
    }
}