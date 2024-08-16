using SQLite4Unity3d;

public class Spacecraft
{
    [PrimaryKey, AutoIncrement, NotNull, Unique] 
    public int id { get; set; }
    
    [NotNull] 
    public string name { get; set; }
    
    public int owner { get; set; }
    
    [NotNull] 
    public int type { get; set; }
}
