using Microsoft.EntityFrameworkCore;

namespace Recipes.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}