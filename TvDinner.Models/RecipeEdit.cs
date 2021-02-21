using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class RecipeEdit
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeIngredients { get; set; }
        public string Instructions { get; set; }
        public int Servings { get; set; }
        public int CaloriesPerServing { get; set; }
    }
}
