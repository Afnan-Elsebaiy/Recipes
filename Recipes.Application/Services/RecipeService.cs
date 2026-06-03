using FluentValidation;
using Mapster;
using Recipes.Application.DTOs.Recipe;
using Recipes.Application.Interfaces;
using Recipes.Application.Validators;
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


        public async Task<int> CreateRecipeAsync(CreateRecipeDto dto)
        {
            var validator = new CreateRecipeValidator();

            var result = await validator.ValidateAsync(dto);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var recipe = dto.Adapt<Recipe>();

            await _repository.AddAsync(recipe);
            await _repository.SaveChangesAsync();

            return recipe.Id;
        }
        public async Task<RecipeDto> GetRecipeByIdAsync(int id)
        {
            var recipe = await _repository.GetByIdAsync(id);

            if (recipe is null)
                throw new KeyNotFoundException(
                    $"Recipe with id {id} not found");

            return recipe.Adapt<RecipeDto>();
        }
    }
}
