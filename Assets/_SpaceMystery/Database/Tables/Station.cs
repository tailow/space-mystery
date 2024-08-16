using SQLite4Unity3d;

public class Station
{
    [NotNull, PrimaryKey, Unique, AutoIncrement]
    public string id { get; set; }
    
    [NotNull]
    public string name { get; set; }
}