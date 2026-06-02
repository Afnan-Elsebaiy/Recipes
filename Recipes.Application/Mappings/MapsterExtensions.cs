using Mapster;

namespace Recipes.Application.Mappings;

public static class MapsterExtensions
{
    public static void RegisterMapsterConfiguration()
    {
        MapsterConfig.RegisterMappings();
    }
}