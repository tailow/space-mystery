using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

public class DataService
{
    private SQLiteConnection _connection;
    
    #if UNITY_EDITOR
        readonly string _databasePath = "Assets/StreamingAssets/database.db";
    #else
        readonly string _databasePath = string.Format("{0}/StreamingAssets/database.db", Application.dataPath);
    #endif

    public DataService()
    {
        _connection = new SQLiteConnection(_databasePath, SQLiteOpenFlags.ReadOnly);
    }

    private string ConvertArgsToSQL(string[] args, Dictionary<string, string> columnMappings)
    {
        string query = "";
        
        bool isFirstArg = true;
        
        foreach (string arg in args)
        {
            string columnName = "";
            string comparisonValue = "";
            string operatorCharacter = "";
            
            if (arg.Contains('<'))
            {
                operatorCharacter = "<";
                columnName = arg.Split('<')[0];
                comparisonValue = arg.Split('<')[1];
            }
            else if (arg.Contains('>'))
            {
                operatorCharacter = ">";
                columnName = arg.Split('>')[0];
                comparisonValue = arg.Split('>')[1];
            }
            else if (arg.Contains('='))
            {
                operatorCharacter = "=";
                columnName = arg.Split('=')[0];
                comparisonValue = arg.Split('=')[1];
            }
            else
            {
                Debug.Log("Option must contain an operator");
            }

            if (columnMappings.ContainsKey(columnName.ToLower()))
            {
                if (isFirstArg)
                {
                    query += " WHERE ";

                    isFirstArg = false;
                }
                else
                {
                    query += " AND ";
                }

                if (int.TryParse(comparisonValue, out int i))
                {
                    query += $"{columnMappings[columnName]}{operatorCharacter}{comparisonValue}";
                }
                else
                {
                    query += $"{columnMappings[columnName]}{operatorCharacter}'{comparisonValue}'";
                }
            }

            else
            {
                Debug.Log("Invalid column");
            }
        }

        return query;
    }

    public IEnumerable<Spacecraft> GetSpacecraft(string[] args)
    {
        string query =
            "SELECT sc.name, sc.owner, st.name AS type, st.maxFuel, st.maxLoad, st.cruiseSpeed, sc.notes" +
            " FROM Spacecraft sc" +
            " INNER JOIN SpacecraftType st " +
            " ON sc.typeId = st.id";
        
        Dictionary<string, string> columnMapping = new Dictionary<string, string>()
        {
            {"name", "sc.name"},
            {"type", "st.name"},
            {"maxfuel", "maxFuel"},
            {"maxload", "maxLoad"},
            {"speed", "cruiseSpeed"}
        };

        query += ConvertArgsToSQL(args, columnMapping);
        
        return _connection.Query<Spacecraft>(query);
    }

    public IEnumerable<Station> GetStations(string[] args)
    {
        string query = "SELECT id, name, notes FROM Station";

        Dictionary<string, string> columnMapping = new Dictionary<string, string>()
        {
            {"id", "id"},
            {"name", "name"},
        };

        query += ConvertArgsToSQL(args, columnMapping);
        
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
        
        Dictionary<string, string> columnMapping = new Dictionary<string, string>()
        {
            {"spacecraft", "s.name"},
            {"station", "stationId"},
            {"time", "arrivalTime"},
            {"reservation", "reservationTime"},
            {"status", "sc.name"}
        };
        
        query += ConvertArgsToSQL(args, columnMapping);
        
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
        
        Dictionary<string, string> columnMapping = new Dictionary<string, string>()
        {
            {"spacecraft", "s.name"},
            {"station", "departureStationId"},
            {"destination", "destinationStationId"},
            {"distance", "destinationDistance"},
            {"time", "departureTime"},
            {"status", "sc.name"}
        };
        
        query += ConvertArgsToSQL(args, columnMapping);
        
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
        
        Dictionary<string, string> columnMapping = new Dictionary<string, string>()
        {
            {"id", "cargoId"},
            {"station", "stationId"},
            {"source", "s1.name"},
            {"destination", "s2.name"},
            {"content", "cargoContent"},
            {"weight", "cargoWeight"},
            {"time", "transferTime"}
        };
        
        query += ConvertArgsToSQL(args, columnMapping);
        
        return _connection.Query<CargoTransfer>(query);
    }
}
