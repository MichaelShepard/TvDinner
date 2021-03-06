using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;

namespace TvDinner.Services
{
    public class RecipeIngredientService
    {
        private readonly Guid _userId;
        public RecipeIngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipeIngredient(RecipeIngredientCreate model)
        {
            var entity =
                new RecipeIngredient()
                {
                    RecipeId = model.RecipeId,
                    IngredientId = model.IngredientId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeIngredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
