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


        public async Task<ApiResponse<RecipeDto>> CreateRecipeAsync(CreateRecipeDto dto)
        {
            var result = await _validator.ValidateAsync(dto);

            if(!result.IsValid)
            {
                return ResponseHelper.Failed<RecipeDto>(
                    string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
                  );
            }
            var recipe = dto.Adapt<Recipe>();

            await _repository.AddAsync(recipe);
            await _repository.SaveChangesAsync();

            return ResponseHelper.Created(
                recipe.Adapt<RecipeDto>(),
                "Recipe created successfully"
            );
        }



        public async Task<ApiResponse<RecipeDto>> GetRecipeByIdAsync(int id)
        {
            if (id <= 0)
            {
                return ResponseHelper.Failed<RecipeDto>(
                    "Id must be greater than zero"
                );
            }

            var recipe = await _repository.GetByIdAsync(id);

            return recipe is null
            ? ResponseHelper.NotFound<RecipeDto>(
                "Recipe not found"
              )
            : ResponseHelper.Success(
                recipe.Adapt<RecipeDto>(),
                "Recipe retrieved successfully"
              );
        }


    }
}
