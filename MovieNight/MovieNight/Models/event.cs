using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int eventID { get; set; }
        public int eventOwner { get; set; }
        public String eventName { get; set; }
        public String eventLocation { get; set; }
        public DateTime eventTime { get; set; }
        public int ticketsBought { get; set; } //Number of tickets purchased
        public int numTickets { get; set; } //Number of tickets left to be claimed
        public int groupID { get; set; } 
        public int movieID { get; set; } 
        public List<User> usersAttending { get; set; }
    }
}