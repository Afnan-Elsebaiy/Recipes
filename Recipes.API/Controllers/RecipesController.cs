using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.DTOs.Recipe;
using Recipes.Application.Interfaces;
using Recipes.Domain.Entities;

namespace Recipes.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : BaseController
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
            var response = await _recipeService.GetByIdAsync(id);

            return HandleResponse(response);
        }

       

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDto dto)
        {
            var response = await _recipeService.CreateAsync(dto);

             return HandleResponse(response);
        }
    }
}
