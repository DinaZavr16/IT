using BusinessLogic.Abstractions;
using BusinessLogic.Managers;
using DataLayer.Entities;
using DataLayer.Entities.Columns.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class ProgramExtensions
    {
        public static void AddBusinessLogicLayerDependensies(this IServiceCollection services)
        {
            services.AddManagers();
        }

        private static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IEntityManager<Database>, EntityManager<Database>>();
            services.AddScoped<IEntityManager<Table>, EntityManager<Table>>();
            services.AddScoped<IEntityManager<Column>, EntityManager<Column>>();
            services.AddScoped<IEntityManager<Row>, EntityManager<Row>>();
        }
    }
}