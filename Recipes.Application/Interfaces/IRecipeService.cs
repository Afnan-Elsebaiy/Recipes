using Recipes.Application.Common.Responses;
using Recipes.Application.DTOs.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<ApiResponse<RecipeDto>> CreateAsync(CreateRecipeDto dto);
        Task<ApiResponse<RecipeDto>> GetByIdAsync(int id);
    }
}
