using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class RecipeCreate
    {
        [Required]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string RecipeName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string RecipeIngredients { get; set; }
        [Required]
        public string Instructions { get; set; }

        public int Servings { get; set; }

        public int Calories { get; set; }

        public int MediaId { get; set; }
    }
}
