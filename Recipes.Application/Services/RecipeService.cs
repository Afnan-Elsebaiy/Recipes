using Mapster;
using Recipes.Application.DTOs.Recipe;
using Recipes.Application.Interfaces;
using Recipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Services
{


    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeService(
            IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(
            CreateRecipeDto dto)
        {
            var recipe = dto.Adapt<Recipe>();

            await _repository.AddAsync(recipe);

            await _repository.SaveChangesAsync();

            return recipe.Id;
        }
    }
}
