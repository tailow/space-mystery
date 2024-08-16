using System.Linq;
using UnityEngine;
using SQLite4Unity3d;

public class DatabaseTest : MonoBehaviour
{
    readonly string dbPath = "Assets/StreamingAssets/database.db";

    private void Start()
    {
        SQLiteConnection connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadOnly);
        
        Debug.Log(connection.Table<Spacecraft>().First().name);
        Debug.Log(connection.Table<SpacecraftType>().First().name);
        Debug.Log(connection.Table<Arrival>().First().time);
        Debug.Log(connection.Table<Departure>().First().time);
        Debug.Log(connection.Table<Station>().First().name);
    }
}
