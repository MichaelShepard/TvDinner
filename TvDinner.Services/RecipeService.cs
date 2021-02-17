using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;
using TvDinner.Models;

namespace TvDinner.Services
{
    public class RecipeService
    {
        private readonly int _recipeId;
        public RecipeService(int recipeId)
        {
            _recipeId = recipeId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    RecipeName = model.RecipeName,
                    RecipeIngredients = model.RecipeIngredients,
                    CaloriesPerServing = model.Calories,
                    Servings = model.Servings,
                    Instructions = model.Instructions,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipe()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var recipe = ctx.Recipes.Find()
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.RecipeId == _recipeId)
                    .Select(
                        e =>
                        new RecipeListItem
                        {
                            RecipeId = e.RecipeId,
                            RecipeName = e.RecipeName,
                        }
            );
                return query.ToArray();
            }
        }
    }
}
