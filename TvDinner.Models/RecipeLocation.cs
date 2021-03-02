using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Models
{
    public class RecipeLocation
    {
        public string RecipeName { get; set; }
        public string RecipeIngredients { get; set; }
        public string Instructions { get; set; }
        public int Servings { get; set; }
        public int CaloriesPerServing { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string State_Territory { get; set; }
        public string City { get; set; }

    }
}
