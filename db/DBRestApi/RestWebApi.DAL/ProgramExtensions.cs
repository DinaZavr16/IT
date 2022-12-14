using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class ProgramExtensions
    {
        public static void AddDataAccessLayerDependensies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestWebApiDbContext>(opts =>
              opts.UseSqlServer(configuration["ConnectionStrings:RestDatabaseConnection"]));
        }
    }
}