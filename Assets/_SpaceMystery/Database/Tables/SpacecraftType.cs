using SQLite4Unity3d;

public class SpacecraftType
{
    [PrimaryKey, AutoIncrement, NotNull, Unique] 
    public int id { get; set; }
    
    [NotNull] 
    public string name { get; set; }
    
    public int maxFuel { get; set; }
}
