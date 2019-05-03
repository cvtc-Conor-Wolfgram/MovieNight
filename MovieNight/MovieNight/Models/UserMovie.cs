using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [Table("UserMovie")]
    public class UserMovie
    {
        [Key, Column(Order = 0)]
        public int userID { get; set; }
        [Key, Column(Order = 1)]
        public int movieID { get; set; }
    }
}