using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    public class MovieNightContext : DbContext
    {
        public DbSet<Movie> movies { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserGroup> userGroup { get; set; }
        public DbSet<UserMovie> userMovie { get; set; }
    }
}