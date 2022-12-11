using DataLayer.Entities.Columns.Abstractions;
using DataLayer.Entities.Columns.Enums;

namespace DataLayer.Entities.Columns;

public class CharColumn : Column
{
    public new ColumnType Type { get; } = ColumnType.Char;
    public CharColumn(string name) : base(name) { }

    public bool Validate(string value) => char.TryParse(value, out _);
}