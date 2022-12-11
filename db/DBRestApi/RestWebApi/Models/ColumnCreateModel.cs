using DataLayer.Entities.Columns.Enums;

namespace WebApi.Models
{
    public class ColumnCreateModel
    {
        public string Name { get; set; }
        public ColumnType Type { get; }

        public Guid TableId { get; set; }
    }
}
