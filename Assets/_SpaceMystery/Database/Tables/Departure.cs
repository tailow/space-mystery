using SQLite4Unity3d;

public class Departure
{
    [NotNull, PrimaryKey, Unique, AutoIncrement]
    public int id { get; set; }
    
    [NotNull]
    public int spacecraftId { get; set; }
    
    [NotNull]
    public string stationId { get; set; }
    
    public int time { get; set; }    
}