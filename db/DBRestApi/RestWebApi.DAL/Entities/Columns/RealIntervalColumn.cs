using DataLayer.Entities.Columns.Abstractions;
using DataLayer.Entities.Columns.Enums;
using System.Text.RegularExpressions;

namespace DataLayer.Entities.Columns;


public class RealIntervalColumn : Column
{
    public new ColumnType Type { get; } = ColumnType.RealInterval;
    public RealIntervalColumn(string name) : base(name) { }
    public static readonly Regex RegexReal = new(@"/\d+\.\.\d+/");

    public bool Validate(string value) => RegexReal.IsMatch(value);
}