using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Data
{
    public class Recipe
    {
        //public Recipe()
        //{
        //    this.RecipeIngredients = new HashSet<Ingredient>();
        //}

        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
        [Required]
        public string Instructions { get; set; }
        public int Servings { get; set; }
        public int CaloriesPerServing { get; set; }

        [ForeignKey(nameof(Media))]
        public int MediaId { get; set; }
        public virtual Media Media { get; set; }
    }
}
