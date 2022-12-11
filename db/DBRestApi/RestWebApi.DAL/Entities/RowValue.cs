namespace DataLayer.Entities;

public class RowValue : BaseEntity
{
    public Guid RowId { get; set; }

    public string Column { get; set; }
    public string Value { get; set; }

}
