using FluentValidation;
using Mapster;
using Recipes.Application.Common.Responses;
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
        private readonly IValidator<CreateRecipeDto> _validator;

        public RecipeService(
            IRepository<Recipe> repository,
            IValidator<CreateRecipeDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }


        public async Task<ApiResponse<RecipeDto>> CreateAsync(CreateRecipeDto dto)
        {
            var result = await _validator.ValidateAsync(dto);

            return !result.IsValid
                ? ResponseHelper.Failed<RecipeDto>(
                    string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
                  )
                : await CreateRecipeInternal(dto);
        }

        private async Task<ApiResponse<RecipeDto>> CreateRecipeInternal(CreateRecipeDto dto)
        {
            var recipe = dto.Adapt<Recipe>();

            await _repository.AddAsync(recipe);
            await _repository.SaveChangesAsync();

            return ResponseHelper.Created(
                recipe.Adapt<RecipeDto>(),
                "Recipe created successfully"
            );
        }

        public async Task<ApiResponse<RecipeDto>> GetByIdAsync(int id)
        {
            var recipe = await _repository.GetByIdAsync(id);

            return recipe is null
                ? ResponseHelper.NotFound<RecipeDto>("Recipe not found")
                : ResponseHelper.Success(
                    recipe.Adapt<RecipeDto>(),
                    "Recipe retrieved successfully");
        }


    }
}
