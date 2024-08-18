using System;
using System.Collections.Generic;
using System.Linq;

public class SearchCommand : Command
{
    public override string Execute(string[] args)
    {
        if (args.Length <= 1) return "Please input the table to be searched.";
        
        DataService dataService = new DataService();
        
        string queryOutput = "";
        
        switch (args[1].ToLower())
        {
            case "spacecraft":
                IEnumerable<Spacecraft> spacecraftData = dataService.GetSpacecraft(args.Skip(2).ToArray());

                DatabaseResults.Instance.ShowSpacecraftResults(spacecraftData);
                
                break;
            case "stations":
                IEnumerable<Station> stationData = dataService.GetStations(args.Skip(2).ToArray());
                
                DatabaseResults.Instance.ShowStationResults(stationData);
                
                break;
            case "arrivals":
                IEnumerable<Arrival> arrivalData = dataService.GetArrivals(args.Skip(2).ToArray());
                
                DatabaseResults.Instance.ShowArrivalResults(arrivalData);
                
                break;
            case "departures":
                IEnumerable<Departure> departureData = dataService.GetDepartures(args.Skip(2).ToArray());
                
                DatabaseResults.Instance.ShowDepartureResults(departureData);
                
                break;
            case "cargo":
                IEnumerable<CargoTransfer> cargoTransferData = dataService.GetCargoTransfers(args.Skip(2).ToArray());
                
                DatabaseResults.Instance.ShowCargoResults(cargoTransferData);
                
                break;
            default:
                queryOutput = "Invalid table. Available tables are: arrivals, departures, cargo, spacecraft, stations";
                break;
        }
        
        return queryOutput;
    }
}
