using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.DTOs.Recipe;
using Recipes.Application.Interfaces;
using Recipes.Application.Responses;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Working");
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateRecipeDto dto)
        {
            var id = await _recipeService.CreateAsync(dto);

            return Ok(new ApiResponse<int>
            {
                Success = true,
                Message = "Recipe created successfully",
                Data = id
            });
        }
    }
}
