using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Data
{
    public class Location
    {
        [Key]
        [Required]
        public int LocationID { get; set; }
        [Required]
        public string Continent { get; set; }
        [Required]
        public string Country { get; set;}
        [Required]
        public string State_Territory { get; set; }
        [Required]
        public string City { get; set; }

        public virtual ICollection<Media> Medias { get; set; }  // Foreign Key

    } 
}
