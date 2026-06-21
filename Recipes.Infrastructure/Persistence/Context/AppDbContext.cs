using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities;

namespace Recipes.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
}