using Recipes.Application.DTOs.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<int> CreateRecipeAsync(CreateRecipeDto dto);
        Task<RecipeDto> GetRecipeByIdAsync(int id);
    }
}
