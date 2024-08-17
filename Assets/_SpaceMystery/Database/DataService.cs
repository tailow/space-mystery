using System.Collections.Generic;
using SQLite4Unity3d;

public class DataService
{
    private SQLiteConnection _connection;
    
    readonly string _databasePath = "Assets/StreamingAssets/database.db";

    public DataService()
    {
        _connection = new SQLiteConnection(_databasePath, SQLiteOpenFlags.ReadOnly);
    }

    public IEnumerable<Spacecraft> GetSpacecraft()
    {
        return _connection.Query<Spacecraft>("SELECT Spacecraft.name, Spacecraft.owner, SpacecraftType.name AS type, SpacecraftType.maxFuel " +
                                             "FROM Spacecraft " +
                                             "INNER JOIN SpacecraftType ON Spacecraft.typeId = SpacecraftType.id");
    }
}
