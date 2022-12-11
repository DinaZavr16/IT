using DataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Abstractions
{
    public interface IEntityManager<Entity> where Entity : BaseEntity, new()
    {
        List<Entity> GetAll(HttpContext httpContext);

        Task<Entity?> GetByIdAsync(HttpContext httpContext, Guid Id);

        Task<Entity> CreateAsync(Entity model);

        Task<Entity> UpdateAsync(Entity model);

        Task<Entity> DeleteAsync(Entity model);
    }
}
