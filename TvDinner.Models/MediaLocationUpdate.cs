using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class MediaLocationUpdate
    {
        public int MediaId { get; set; }

        public int? LocationID { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
