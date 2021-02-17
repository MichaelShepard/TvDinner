using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;

namespace TvDinner.Models
{
    public class MediaCreate
    {

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        public MediaType MediaType { get; set; }

        public string SeasonEpisode { get; set; }

        public string SceneOfFood { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }


    }
}
