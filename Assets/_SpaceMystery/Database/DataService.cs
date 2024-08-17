using System.Collections.Generic;
using SQLite4Unity3d;

public class DataService
{
    private SQLiteConnection _connection;
    
    readonly string databasePath = "Assets/StreamingAssets/database.db";

    public DataService()
    {
        _connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadOnly);
    }

    public IEnumerable<SpacecraftQuery> GetSpacecraftData()
    {
        return _connection.Query<SpacecraftQuery>("SELECT Spacecraft.name, Spacecraft.owner, SpacecraftType.name AS type, SpacecraftType.maxFuel " +
                                             "FROM Spacecraft " +
                                             "INNER JOIN SpacecraftType ON Spacecraft.typeId = SpacecraftType.id");
    }
}
