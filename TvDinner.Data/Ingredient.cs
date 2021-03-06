using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Data
{
    public class Ingredient
    {
        //public Ingredient()
        //{
        //    this.Recipes = new HashSet<Recipe>();
        //}

        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string UnitOfMeasure { get; set; }
        public virtual List<RecipeIngredient> Recipeingredients { get; set; }
    }
}
