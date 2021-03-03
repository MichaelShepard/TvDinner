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
       [HttpGet]
       public IHttpActionResult Get(int id)
        {
            RecipeService recipeService = CreateRecipeService();
            var recipes = recipeService.GetRecipe(id);
            return Ok(recipes);
        }

        [HttpGet]
        [Route("api/Recipe/GetIngredientsByRecipe")]
        public IHttpActionResult GetIngredientsByRecipe(int id)
        {
            RecipeService recipeService = CreateRecipeService();
            var recipeIngredients = recipeService.IngredientsByRecipe(id);
            return Ok(recipeIngredients);
        }

        [HttpPost]
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

        [HttpPost]
        public IHttpActionResult Put(RecipeEdit recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.UpdateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeService();

            if (!service.DeleteRecipe(id))
                return InternalServerError();

            return Ok();
        }
    }
}
