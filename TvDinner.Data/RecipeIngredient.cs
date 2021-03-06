using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDinner.Data
{
    public class RecipeIngredient
    {
        [Key,Column(Order=0)]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
