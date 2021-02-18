using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public List<string> RecipeIngredients { get; set; }
        public List<string> Instructions { get; set; }
        public int Servings { get; set; }
        public int CaloriesPerServing { get; set; }
    }
}
