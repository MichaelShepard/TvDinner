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
        private readonly Guid _userId;
        public RecipeService(Guid userId)
        {
            _userId = userId;
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

        public RecipeDetail GetRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeId == id);
                return
                 new RecipeDetail
                 {
                     RecipeId = entity.RecipeId,
                     RecipeName = entity.RecipeName,
                     RecipeIngredients = entity.RecipeIngredients,
                     Instructions = entity.Instructions,
                     Servings = entity.Servings,
                     CaloriesPerServing = entity.CaloriesPerServing
                 };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeId == model.RecipeId);

                entity.RecipeId = model.RecipeId;
                entity.RecipeName = model.RecipeName;
                entity.RecipeIngredients = model.RecipeIngredients;
                entity.Instructions = model.Instructions;
                entity.Servings = model.Servings;
                entity.CaloriesPerServing = model.CaloriesPerServing;

                return ctx.SaveChanges() == 1;
            }
        }



        //public IEnumerable<RecipeListItem> GetRecipe()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        //var recipe = ctx.Recipes.Find()
        //        var query =
        //            ctx
        //            .Recipes
        //            .Where(e => e.RecipeId == _recipeId)
        //            .Select(
        //                e =>
        //                new RecipeListItem
        //                {
        //                    RecipeId = e.RecipeId,
        //                    RecipeName = e.RecipeName,
        //                }
        //    );
        //        return query.ToArray();
        //    }
        //}
    }
}
