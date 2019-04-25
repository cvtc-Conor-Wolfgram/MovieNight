using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int movieID { get; set; }
        public String omdbCode { get; set; }
    }
}