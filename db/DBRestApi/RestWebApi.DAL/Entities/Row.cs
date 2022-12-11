namespace DataLayer.Entities;

public class Row : BaseEntity
{
    public Guid TableId { get; set; }
    public Table Table { get; set; }

    public ICollection<RowValue> RowValues { get; set; }
}
