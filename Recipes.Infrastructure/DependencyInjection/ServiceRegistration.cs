using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Application.Interfaces;
using Recipes.Infrastructure.Persistence.Context;
using Recipes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Infrastructure.DependencyInjection
{
  

    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(
                typeof(IRepository<>),
                typeof(Repository<>));

            return services;
        }
    }
}
