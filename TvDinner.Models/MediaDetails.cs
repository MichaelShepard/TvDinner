using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;

namespace TvDinner.Models
{
    public class MediaDetails
    {

        public int MediaId { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public MediaType MediaType { get; set; }

        public string SeasonEpisode { get; set; }

        public string SceneOfFood { get; set; }

        public int LocationId { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }


    }
}
