using DataLayer.Entities.Columns.Abstractions;
using DataLayer.Entities.Columns.Enums;

namespace DataLayer.Entities.Columns;

public class PictureColumn : Column
{
    public new ColumnType Type { get; } = ColumnType.Picture;
    public PictureColumn(string name) : base(name) { }

    public bool Validate(string value) => true;
}