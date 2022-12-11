using DataLayer.Entities.Columns.Abstractions;
using DataLayer.Entities.Columns.Enums;

namespace DataLayer.Entities.Columns;

public class RealColumn : Column
{
    public new ColumnType Type { get; } = ColumnType.Real;
    public RealColumn(string name) : base(name) { }

    public bool Validate(string value) => double.TryParse(value, out _);
}