using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class LocationEdit
    {
       
        public int LocationID { get; set; }
       
        public string Continent { get; set; }
        
        public string Country { get; set; }
        
        public string State_Territory { get; set; }
        
        public string City { get; set; }
    }
}
