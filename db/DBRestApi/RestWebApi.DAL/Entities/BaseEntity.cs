using DataLayer.Entities.LinkGeneratorEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    [NotMapped]
    public List<Link> Links { get; set; } = new List<Link>();
}
