using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.DTOs.Recipe;
using Recipes.Application.Interfaces;
using Recipes.Application.Responses;
using Recipes.Domain.Entities;

namespace Recipes.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(
            IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);

            if (recipe is null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(
        CreateRecipeDto dto)
        {
            var recipe = await _recipeService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetRecipeById),
                new { id = recipe.Id },
                recipe);
        }
    }
}
