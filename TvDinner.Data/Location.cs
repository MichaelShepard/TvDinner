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
        public int LocationID { get; set; }
        public string Continent { get; set; }
        public string Country { get; set;}
        public string State_Territory { get; set; }
        public string City { get; set; }
    } 
}
