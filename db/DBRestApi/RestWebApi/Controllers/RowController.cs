using BusinessLogic.Abstractions;
using DataLayer.Entities;
using DataLayer.Entities.LinkGeneratorEntities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RowController : ControllerBase
    {
        private readonly IEntityManager<Row> _entityManager;
        private LinkGenerator _linkGenerator;

        public RowController(IEntityManager<Row> entityManager, LinkGenerator linkGenerator)
        {
            _entityManager = entityManager;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public LinkCollectionWrapper<Row> GetAll()
        {
            var res = _entityManager.GetAll(HttpContext);
            for (var index = 0; index < res.Count(); index++)
            {
                var entityLinks = CreateLinksForEntity(HttpContext, res[index].Id);
                res[index].Links.AddRange(entityLinks);
            }
            var entitiesWrapper = new LinkCollectionWrapper<Row>(res);
            return CreateLinksForEntities(HttpContext, entitiesWrapper);
        }

        private IEnumerable<Link> CreateLinksForEntity(HttpContext httpContext, Guid id)
        => new List<Link>
        {
                new Link(_linkGenerator.GetUriByAction(httpContext, nameof(GetById), values: new { id }), "self","GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext, nameof(Delete)), "delete_entity", "DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext, nameof(Update)), "update_entity", "PUT"),
                new Link(_linkGenerator.GetUriByAction(httpContext, nameof(Create)), "create_entity", "POST")
           };

        private LinkCollectionWrapper<Row> CreateLinksForEntities(HttpContext httpContext, LinkCollectionWrapper<Row> ownersWrapper)
        {
            ownersWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, nameof(GetAll), values: new { }), "self", "GET"));
            return ownersWrapper;
        }

        [HttpGet("{id}")]
        public async Task<Row?> GetById(Guid id) => await _entityManager.GetByIdAsync(HttpContext, id);

        [HttpPost]
        public async Task<Row> Create(RowCreateModel model) => await _entityManager.CreateAsync(model.Adapt<Row>());

        [HttpPut]
        public async Task<Row> Update(Row model) => await _entityManager.UpdateAsync(model);

        [HttpDelete]
        public async Task<Row> Delete(Row model) => await _entityManager.DeleteAsync(model);
    }
}