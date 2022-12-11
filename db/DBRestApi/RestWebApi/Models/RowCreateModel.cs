using DataLayer.Entities;

namespace WebApi.Models
{
    public class RowCreateModel
    {
        public Guid TableId { get; set; }

        public ICollection<RowValue> RowValues { get; set; }
    }
}
