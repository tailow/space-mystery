using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DatabaseResults : Singleton<DatabaseResults>
{
    [SerializeField] private GameObject databaseResults;
    
    [SerializeField] private GameObject titleRowPrefab;
    [SerializeField] private GameObject titleColumnPrefab;
    [SerializeField] private GameObject resultRowPrefab;
    [SerializeField] private GameObject resultColumnPrefab;

    private void DeleteResults()
    {
        foreach (Transform child in databaseResults.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void HideResults()
    {
        databaseResults.SetActive(false);
    }
    
    public void ShowStationResults(IEnumerable<Station> stationData)
    {
        DeleteResults();
        
        databaseResults.SetActive(true);
        
        string[] stationTitles = new[] { "ID", "NAME", "NOTES" };
        
        InstantiateTitleRow(stationTitles);

        foreach (Station station in stationData)
        {
            string[] stationResults = new[] { station.id, station.name, station.notes };
            
            InstantiateResultRow(stationResults);
        }
    }
    
    public void ShowSpacecraftResults(IEnumerable<Spacecraft> spacecraftData)
    {
        DeleteResults();
        
        databaseResults.SetActive(true);
        
        string[] titles = new[] { "NAME", "TYPE", "MAXFUEL", "MAXLOAD", "SPEED", "NOTES" };
        
        InstantiateTitleRow(titles);

        foreach (Spacecraft spacecraft in spacecraftData)
        {
            string[] results = new[] { spacecraft.name, spacecraft.type, spacecraft.maxFuel.ToString(),
                                        spacecraft.maxLoad.ToString(), spacecraft.cruiseSpeed.ToString(), spacecraft.notes };
            
            InstantiateResultRow(results);
        }
    }
    
    public void ShowArrivalResults(IEnumerable<Arrival> arrivalData)
    {
        DeleteResults();
        
        databaseResults.SetActive(true);
        
        string[] titles = new[] { "SPACECRAFT", "STATION", "TIME", "RESERVATION", "STATUS", "NOTES" };
        
        InstantiateTitleRow(titles);

        foreach (Arrival arrival in arrivalData)
        {
            string[] results = new[] { arrival.spacecraftName, arrival.stationId, arrival.arrivalTime.ToString(),
                arrival.reservationTime.ToString(), arrival.statusCode, arrival.notes };
            
            InstantiateResultRow(results);
        }
    }
    
    public void ShowDepartureResults(IEnumerable<Departure> departureData)
    {
        DeleteResults();
        
        databaseResults.SetActive(true);
        
        string[] titles = new[] { "SPACECRAFT", "STATION", "DESTINATION", "DISTANCE", "TIME", "STATUS", "NOTES" };
        
        InstantiateTitleRow(titles);

        foreach (Departure departure in departureData)
        {
            string[] results = new[]
            {
                departure.spacecraftName, departure.departureStationId, departure.destinationStationId,
                departure.destinationDistance.ToString(), departure.departureTime.ToString(), departure.statusCode,
                departure.notes
            };
            
            InstantiateResultRow(results);
        }
    }
    
    public void ShowCargoResults(IEnumerable<CargoTransfer> cargoTransferData)
    {
        DeleteResults();
        
        databaseResults.SetActive(true);
        
        string[] titles = new[] { "ID", "STATION", "SOURCE", "DESTINATION", "CONTENT", "WEIGHT", "TIME", "NOTES" };
        
        InstantiateTitleRow(titles);

        foreach (CargoTransfer cargoTransfer in cargoTransferData)
        {
            string[] results = new[]
            {
                cargoTransfer.cargoId.ToString(), cargoTransfer.stationId, cargoTransfer.startSpacecraftName,
                cargoTransfer.destinationSpacecraftName, cargoTransfer.cargoContent, cargoTransfer.cargoWeight.ToString(),
                cargoTransfer.transferTime.ToString(), cargoTransfer.notes
            };
            
            InstantiateResultRow(results);
        }
    }
    
    private void InstantiateTitleRow(string[] titles)
    {
        GameObject titleRow = Instantiate(titleRowPrefab, databaseResults.transform);
        
        foreach (string title in titles)
        {
            GameObject titleColumn = Instantiate(titleColumnPrefab, titleRow.transform);

            titleColumn.GetComponentInChildren<TMP_Text>().text = title;
        }
    }

    private void InstantiateResultRow(string[] results)
    {
        GameObject resultRow = Instantiate(resultRowPrefab, databaseResults.transform);
        
        foreach (string result in results)
        {
            GameObject resultColumn = Instantiate(resultColumnPrefab, resultRow.transform);

            resultColumn.GetComponentInChildren<TMP_Text>().text = result;
        }
    }
}
