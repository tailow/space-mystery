using System;
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

    [SerializeField] private TMP_Text resultsTitleText;
    [SerializeField] private TMP_Text resultsCountText;

    private List<ResultRow> resultRows = new List<ResultRow>();
    
    private int selectedRowIndex = -1;
    private int maxDisplayedRows = 18;

    private float selectionCooldown = 0.1f;
    private float previousSelectionTime;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Time.time - previousSelectionTime > selectionCooldown)
        {
            if (selectedRowIndex >= 0) resultRows[selectedRowIndex].Deselect();
            
            selectedRowIndex++;

            selectedRowIndex = Math.Min(resultRows.Count - 1, selectedRowIndex);
            
            resultRows[selectedRowIndex].Select();

            if (selectedRowIndex >= maxDisplayedRows)
            {
                for (int i = 0; i < selectedRowIndex - maxDisplayedRows + 1; i++)
                {
                    resultRows[i].gameObject.SetActive(false);
                }
            }

            previousSelectionTime = Time.time;
        }
        
        else if (Input.GetKey(KeyCode.UpArrow) && Time.time - previousSelectionTime > selectionCooldown)
        {
            if (selectedRowIndex >= 0) resultRows[selectedRowIndex].Deselect();
            
            selectedRowIndex--;

            selectedRowIndex = Math.Max(0, selectedRowIndex);
            
            resultRows[selectedRowIndex].Select();
            
            resultRows[selectedRowIndex].gameObject.SetActive(true);
            
            previousSelectionTime = Time.time;
        }
    }
    
    private void DeleteResults()
    {
        resultRows.Clear();

        selectedRowIndex = -1;
        
        foreach (Transform child in databaseResults.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void HideResults()
    {
        databaseResults.transform.parent.gameObject.SetActive(false);
    }
    
    public void ShowStationResults(IEnumerable<Station> stationData)
    {
        DeleteResults();
        
        databaseResults.transform.parent.gameObject.SetActive(true);
        
        string[] stationTitles = new[] { "ID", "NAME", "NOTES" };
        
        InstantiateTitleRow(stationTitles);

        foreach (Station station in stationData)
        {
            string[] stationResults = new[] { station.id, station.name, station.notes };
            
            InstantiateResultRow(stationResults);
        }

        resultsTitleText.text = "Stations";
        resultsCountText.text = $"Query results: {stationData.Count()}";
    }
    
    public void ShowSpacecraftResults(IEnumerable<Spacecraft> spacecraftData)
    {
        DeleteResults();
        
        databaseResults.transform.parent.gameObject.SetActive(true);
        
        string[] titles = new[] { "NAME", "TYPE", "MAXFUEL", "MAXLOAD", "SPEED", "NOTES" };
        
        InstantiateTitleRow(titles);

        foreach (Spacecraft spacecraft in spacecraftData)
        {
            string[] results = new[] { spacecraft.name, spacecraft.type, spacecraft.maxFuel.ToString(),
                                        spacecraft.maxLoad.ToString(), spacecraft.cruiseSpeed.ToString(), spacecraft.notes };
            
            InstantiateResultRow(results);
        }
        
        resultsTitleText.text = "Spacecraft";
        resultsCountText.text = $"Query results: {spacecraftData.Count()}";
    }
    
    public void ShowArrivalResults(IEnumerable<Arrival> arrivalData)
    {
        DeleteResults();
        
        databaseResults.transform.parent.gameObject.SetActive(true);
        
        string[] titles = new[] { "SPACECRAFT", "STATION", "TIME", "RESERVATION", "STATUS", "NOTES" };
        
        InstantiateTitleRow(titles);

        foreach (Arrival arrival in arrivalData)
        {
            string[] results = new[] { arrival.spacecraftName, arrival.stationId, arrival.arrivalTime.ToString(),
                arrival.reservationTime.ToString(), arrival.statusCode, arrival.notes };
            
            InstantiateResultRow(results);
        }
        
        resultsTitleText.text = "Arrivals";
        resultsCountText.text = $"Query results: {arrivalData.Count()}";
    }
    
    public void ShowDepartureResults(IEnumerable<Departure> departureData)
    {
        DeleteResults();
        
        databaseResults.transform.parent.gameObject.SetActive(true);
        
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
        
        resultsTitleText.text = "Departures";
        resultsCountText.text = $"Query results: {departureData.Count()}";
    }
    
    public void ShowCargoResults(IEnumerable<CargoTransfer> cargoTransferData)
    {
        DeleteResults();
        
        databaseResults.transform.parent.gameObject.SetActive(true);
        
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
        
        resultsTitleText.text = "Cargo transfers";
        resultsCountText.text = $"Query results: {cargoTransferData.Count()}";
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
        GameObject resultRowObject = Instantiate(resultRowPrefab, databaseResults.transform);
        
        resultRows.Add(resultRowObject.GetComponent<ResultRow>());
        
        foreach (string result in results)
        {
            GameObject resultColumn = Instantiate(resultColumnPrefab, resultRowObject.transform);

            resultColumn.GetComponentInChildren<TMP_Text>().text = result;
        }
    }
}
