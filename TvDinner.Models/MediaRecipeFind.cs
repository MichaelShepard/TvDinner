using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;

namespace TvDinner.Models
{
    public class MediaRecipeFind
    {

        public string Title { get; set; }

        public string SeasonEpisode { get; set; }

        public string SceneOfFood { get; set; }

        public string RecipeName { get; set; }
      
        public string RecipeIngredients { get; set; }
       
        public string Instructions { get; set; }

        public int Servings { get; set; }
        
        public int CaloriesPerServing { get; set; }

    }
}
