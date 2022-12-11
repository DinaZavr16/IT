using DataLayer.Entities.Columns.Abstractions;
using DataLayer.Entities.Columns.Enums;

namespace DataLayer.Entities.Columns;

public class IntColumn : Column
{
    public new ColumnType Type { get; } = ColumnType.Int;
    public IntColumn(string name) : base(name) { }

    public bool Validate(string value) => int.TryParse(value, out _);
}