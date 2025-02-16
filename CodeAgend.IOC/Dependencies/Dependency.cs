using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.Utility.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeAgenda.IOC.Dependencies
{
    public static class Dependency
    {

        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("cadenaPostgreSQL"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

    }
}
