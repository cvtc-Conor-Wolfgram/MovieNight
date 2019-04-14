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
        public String eventTime { get; set; }
        public bool ticketsBought { get; set; }
        public int numTickets { get; set; }
        public List<User> usersAttending { get; set; }
    }
}