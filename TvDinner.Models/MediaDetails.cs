using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class MediaDetails
    {

        public int MediaId { get; set; }

        public string Title { get; set; }

        public Enum Genre { get; set; }

        public Enum MediaType { get; set; }

        public string SeasonEpisode { get; set; }

        public string SceneOfFood { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }


    }
}
