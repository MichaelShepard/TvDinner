using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class MediaCreate
    {

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        public Enum Genre { get; set; }

        public Enum MediaType { get; set; }

        public string SeasonEpisode { get; set; }

        public string SceneOfFood { get; set; }


    }
}
