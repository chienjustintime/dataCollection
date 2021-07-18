using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SP.Persistence;

namespace SP.Application
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SpConnectionString");
            services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("SP.WebAPI")));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            
        }
    }
}