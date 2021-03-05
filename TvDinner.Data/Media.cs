using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Data
{

    public enum Genre
    {

        Action = 1,
        Comedy,
        Drama,
        Musical,
        Thriller,
        Horror,
        Documentary,
        SciFi,
        RomanticComedy
    }


    public enum MediaType
    {
        Movie = 1 ,
        Tv
    }

    public class Media
    {

        [Key]
        public int MediaId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public MediaType MediaType { get; set; }

        public string SeasonEpisode { get; set; }

        [Required]
        public string SceneOfFood { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        // Foreign Keys

        [ForeignKey(nameof(Location))]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }


        public virtual ICollection<Recipe> Recipes { get; set; }

        // public virtual ICollection<Location> Locations { get; set; }
=======
        


    }
}
