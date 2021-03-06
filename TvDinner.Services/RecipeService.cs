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
                    CaloriesPerServing = model.Calories,
                    Servings = model.Servings,
                    Instructions = model.Instructions,
                    MediaId = model.MediaId
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
                     Instructions = entity.Instructions,
                     Servings = entity.Servings,
                     CaloriesPerServing = entity.CaloriesPerServing,
                     Ingredients = entity.Ingredients.Select(q => new IngredientListItem()
                     {
                         IngredientId = q.Ingredient.IngredientId,
                         IngredientName = q.Ingredient.IngredientName,
                         UnitOfMeasure = q.Ingredient.UnitOfMeasure                       
                     }
                     ).ToList()
                 };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeId == model.RecipeId);

                entity.RecipeId = model.RecipeId;
                entity.RecipeName = model.RecipeName;
                entity.Instructions = model.Instructions;
                entity.Servings = model.Servings;
                entity.CaloriesPerServing = model.CaloriesPerServing;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<RecipeIngredients> IngredientsByRecipe(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx

        //            .Recipes
        //            .Where(e => e.RecipeId == id)
        //            .Select(e => new RecipeIngredients

        //            {
        //                Ingredients = e.RecipeIngredients
        //            });

        //        return query.ToArray();
        //    }
        //}
    }
}
