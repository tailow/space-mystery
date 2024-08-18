using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

public class DataService
{
    private SQLiteConnection _connection;
    
    readonly string _databasePath = "Assets/StreamingAssets/database.db";

    public DataService()
    {
        _connection = new SQLiteConnection(_databasePath, SQLiteOpenFlags.ReadOnly);
    }

    public IEnumerable<Spacecraft> GetSpacecraft(string[] args)
    {
        string query =
            "SELECT Spacecraft.name, Spacecraft.owner, SpacecraftType.name AS type, SpacecraftType.maxFuel " +
            "FROM Spacecraft " +
            "INNER JOIN SpacecraftType ON Spacecraft.typeId = SpacecraftType.id";
        
        bool isFirstArg = true;
        
        foreach (string arg in args)
        {
            if (isFirstArg)
            {
                query += $" WHERE {arg}";

                isFirstArg = false;
            }

            else
            {
                query += $" AND {arg}";
            }
        }
        
        return _connection.Query<Spacecraft>(query);
    }

    public IEnumerable<Station> GetStations(string[] args)
    {
        string query = "SELECT id, name, notes FROM Station";

        bool isFirstArg = true;
        
        foreach (string arg in args)
        {
            if (isFirstArg)
            {
                query += $" WHERE {arg}";

                isFirstArg = false;
            }

            else
            {
                query += $" AND {arg}";
            }
        }
        
        return _connection.Query<Station>(query);
    }

    public IEnumerable<Arrival> GetArrivals(string[] args)
    {
        string query =
            "SELECT s.name AS spacecraftName, a.stationId, a.arrivalTime, a.reservationTime, sc.name AS statusCode, a.notes" +
            " FROM Arrival a" +
            " INNER JOIN Spacecraft s" +
            " ON s.id = a.spacecraftId" +
            " INNER JOIN StatusCode sc" +
            " ON sc.id = a.statusCode";
        
        bool isFirstArg = true;
        
        foreach (string arg in args)
        {
            if (isFirstArg)
            {
                query += $" WHERE {arg}";

                isFirstArg = false;
            }

            else
            {
                query += $" AND {arg}";
            }
        }
        
        return _connection.Query<Arrival>(query);
    }

    public IEnumerable<Departure> GetDepartures(string[] args)
    {
        string query = "SELECT s.name AS spacecraftName, d.departureStationId, d.destinationStationId, " +
                       "d.destinationDistance, d.departureTime, sc.name AS statusCode, d.notes" +
                       " FROM Departure d" +
                       " INNER JOIN Spacecraft s" +
                       " ON s.id = d.spacecraftId" +
                       " INNER JOIN StatusCode sc" +
                       " ON sc.id = d.statusCode";
        
        bool isFirstArg = true;
        
        foreach (string arg in args)
        {
            if (isFirstArg)
            {
                query += $" WHERE {arg}";

                isFirstArg = false;
            }

            else
            {
                query += $" AND {arg}";
            }
        }
        
        return _connection.Query<Departure>(query);
    }

    public IEnumerable<CargoTransfer> GetCargoTransfers(string[] args)
    {
        string query =
            "SELECT ct.cargoId, ct.stationId, s1.name AS startSpacecraftName, s2.name AS destinationSpacecraftName," +
            " ct.cargoContent, ct.cargoWeight, ct.transferTime, ct.notes" +
            " FROM CargoTransfer ct" +
            " INNER JOIN Spacecraft s1" +
            " ON ct.startSpacecraftId = s1.id" +
            " INNER JOIN Spacecraft s2" +
            " ON ct.destinationSpacecraftId = s2.id";
        
        bool isFirstArg = true;
        
        foreach (string arg in args)
        {
            if (isFirstArg)
            {
                query += $" WHERE {arg}";

                isFirstArg = false;
            }

            else
            {
                query += $" AND {arg}";
            }
        }
        
        return _connection.Query<CargoTransfer>(query);
    }
}
