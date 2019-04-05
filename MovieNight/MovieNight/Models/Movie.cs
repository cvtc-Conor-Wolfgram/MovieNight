using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    public class Movie
    {
        public int movieID { get; set; }
        public int movieIMDBCode { get; set; }
    }
}