using BusinessLogic.Abstractions;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Managers
{
    public class EntityManager<Entity> : IEntityManager<Entity> where Entity : BaseEntity, new()
    {
        public RestWebApiDbContext _dbContext { get; set; }
        private LinkGenerator _linkGenerator;

        public EntityManager(RestWebApiDbContext dbContext, LinkGenerator linkGenerator)
        {
            _dbContext = dbContext;
            _linkGenerator = linkGenerator;
        }

        public List<Entity> GetAll(HttpContext httpContext)
        {
            return _dbContext.Set<Entity>().AsNoTracking().ToList();
        }

        public async Task<Entity?> GetByIdAsync(HttpContext httpContext, Guid Id)
        {
            return await _dbContext.Set<Entity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Entity> CreateAsync(Entity model)
        {
            _dbContext.Set<Entity>().Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Entity> UpdateAsync(Entity model)
        {
            _dbContext.Set<Entity>().Update(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Entity> DeleteAsync(Entity model)
        {
            _dbContext.Set<Entity>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public IQueryable<Entity> ExceptAsync(List<Entity> models)
        {
            var exceptResult = _dbContext.Set<Entity>().Except(models);
            return exceptResult;
        }
    }
}