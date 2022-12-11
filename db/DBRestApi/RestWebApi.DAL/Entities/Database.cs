﻿namespace DataLayer.Entities;

public class Database : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Table> Tables { get; set; } = new List<Table>();

    public Database(string name) => Name = name;
    public Database() { }
}
