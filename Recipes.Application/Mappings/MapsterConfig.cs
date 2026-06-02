using Mapster;
using Recipes.Application.DTOs.Recipe;
using Recipes.Domain.Entities;

namespace Recipes.Application.Mappings;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<
            CreateRecipeDto,
            Recipe>.NewConfig();

        TypeAdapterConfig<
            Recipe,
            RecipeDto>.NewConfig();
    }
}