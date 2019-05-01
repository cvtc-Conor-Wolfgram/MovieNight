using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieNight.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ImdbEntity
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Year")]
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        [JsonProperty(PropertyName = "Poster")]
        public string Poster { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        [JsonProperty(PropertyName = "imdbID")]
        public string imdbID { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
        public string Response { get; set; }
    }
}