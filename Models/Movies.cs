using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate{ get; set; }
        public string MovieBio{ get; set; }
        [JsonIgnore]
        public string[] Actors { get; set; }
        [JsonIgnore]
        public string Producer { get; set; }
        //public string MoviePoster{ get; set; }

        public ICollection<Actors> ActorList { get; set; } = new HashSet<Actors>();
        public ICollection<Producers> ProducerList { get; set; } = new HashSet<Producers>();

    }
}
