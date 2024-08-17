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

    public IEnumerable<Station> GetStations()
    {
        return _connection.Query<Station>("SELECT id, name, notes FROM Station");
    }

    public IEnumerable<Arrival> GetArrivals()
    {
        return _connection.Query<Arrival>("SELECT s.name AS spacecraftName, a.stationId, a.arrivalTime, a.reservationTime, sc.name AS statusCode, a.notes" +
                                          " FROM Arrival a" +
                                          " INNER JOIN Spacecraft s" +
                                          " ON s.id = a.spacecraftId" +
                                          " INNER JOIN StatusCode sc" +
                                          " ON sc.id = a.statusCode");
    }

    public IEnumerable<Departure> GetDepartures()
    {
        return _connection.Query<Departure>("SELECT s.name AS spacecraftName, d.departureStationId, d.destinationStationId, " +
                                            "d.destinationDistance, d.departureTime, sc.name AS statusCode, d.notes" +
                                          " FROM Departure d" +
                                          " INNER JOIN Spacecraft s" +
                                          " ON s.id = d.spacecraftId" +
                                          " INNER JOIN StatusCode sc" +
                                          " ON sc.id = d.statusCode");
    }

    public IEnumerable<CargoTransfer> GetCargoTransfers()
    {
        return _connection.Query<CargoTransfer>("SELECT ct.cargoId, ct.stationId, s1.name AS startSpacecraftName, s2.name AS destinationSpacecraftName," +
                                                " ct.cargoContent, ct.cargoWeight, ct.transferTime, ct.notes" +
                                                " FROM CargoTransfer ct" +
                                                " INNER JOIN Spacecraft s1" +
                                                " ON ct.startSpacecraftId = s1.id" +
                                                " INNER JOIN Spacecraft s2" +
                                                " ON ct.destinationSpacecraftId = s2.id");
    }
}
