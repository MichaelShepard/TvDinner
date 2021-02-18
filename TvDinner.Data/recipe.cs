using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public List<string> RecipeIngredients { get; set; }
        [Required]
        public List<string> Instructions { get; set; }
        public int Servings { get; set; }
        public int CaloriesPerServing { get; set; }
    }
}
