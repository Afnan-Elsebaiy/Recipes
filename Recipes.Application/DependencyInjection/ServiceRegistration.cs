using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Application.Interfaces;
using Recipes.Application.Mappings;
using Recipes.Application.Services;
using System.Reflection;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();

        services.AddValidatorsFromAssembly(
            Assembly.GetExecutingAssembly());

        MapsterConfig.RegisterMappings();
        return services;
    }
}