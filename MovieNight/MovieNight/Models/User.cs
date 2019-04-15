using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int userID { get; set; }
        public String userName { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public virtual int joinNumber { get; set; }
        public virtual int turnToPick { get; set; }
        public List<Movie> moviesSubmitted { get; set; }
        public List<Group> groups { get; set; }
        public List<Event> events { get; set; }

        public User()
        {

        }
    }
}