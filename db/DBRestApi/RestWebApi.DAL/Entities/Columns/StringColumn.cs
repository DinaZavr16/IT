using DataLayer.Entities.Columns.Abstractions;
using DataLayer.Entities.Columns.Enums;

namespace DataLayer.Entities.Columns;
public class StringColumn : Column
{
    public new ColumnType Type { get; } = ColumnType.String;
    public StringColumn(string name) : base(name) { }

    public bool Validate(string value) => true;
}