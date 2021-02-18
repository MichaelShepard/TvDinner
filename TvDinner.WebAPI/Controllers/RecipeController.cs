using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TvDinner.Data;
using TvDinner.Models;
using TvDinner.Services;

namespace TvDinner.WebAPI.Controllers
{
    [Authorize]
    public class RecipeController : ApiController
    {
       public IHttpActionResult Get()
        {
            RecipeService recipeService = CreateRecipeService();
            var recipes = recipeService.GetRecipe();
            return Ok(recipes);
        }

        public IHttpActionResult Post(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.CreateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }

       private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var recipeService = new RecipeService(userId);
            return recipeService;
        }
    }
}
