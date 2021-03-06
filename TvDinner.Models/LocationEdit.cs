using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class LocationEdit
    {
        [Required]
        [MaxLength(500, ErrorMessage = "500 or less characters please.")]
        public string Continent { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "500 or less characters please.")]
        public string Country { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "500 or less characters please.")]
        public string State_Territory { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "500 or less characters please.")]
        public string City { get; set; }
    }
}
