using Recipes.Application.DTOs.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<int> CreateAsync(CreateRecipeDto dto);
        Task<RecipeDto> GetByIdAsync(int id);
    }
}
