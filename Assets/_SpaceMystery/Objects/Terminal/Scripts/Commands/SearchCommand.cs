using System;
using System.Collections.Generic;
using System.Linq;

public class SearchCommand : Command
{
    public override string Execute(string[] args)
    {
        if (args.Length <= 1) return "Please input the table to be searched. Available tables are: arrivals, departures, cargo, spacecraft, stations";
        
        DataService dataService = new DataService();
        
        string queryOutput = "";
        
        switch (args[1].ToLower())
        {
            case "spacecraft":
                Tuple<bool, IEnumerable<Spacecraft>> spacecraftData = dataService.GetSpacecraft(args.Skip(2).ToArray());

                if (!spacecraftData.Item1) break;

                DatabaseResults.Instance.ShowSpacecraftResults(spacecraftData.Item2);
                
                break;
            case "stations":
                Tuple<bool, IEnumerable<Station>> stationData = dataService.GetStations(args.Skip(2).ToArray());
                
                if (!stationData.Item1) break;
                
                DatabaseResults.Instance.ShowStationResults(stationData.Item2);
                
                break;
            case "arrivals":
                Tuple<bool, IEnumerable<Arrival>> arrivalData = dataService.GetArrivals(args.Skip(2).ToArray());
                
                if (!arrivalData.Item1) break;
                
                DatabaseResults.Instance.ShowArrivalResults(arrivalData.Item2);
                
                break;
            case "departures":
                Tuple<bool, IEnumerable<Departure>> departureData = dataService.GetDepartures(args.Skip(2).ToArray());
                
                if (!departureData.Item1) break;
                
                DatabaseResults.Instance.ShowDepartureResults(departureData.Item2);
                
                break;
            case "cargo":
                Tuple<bool, IEnumerable<CargoTransfer>> cargoTransferData = dataService.GetCargoTransfers(args.Skip(2).ToArray());
                
                if (!cargoTransferData.Item1) break;
                
                DatabaseResults.Instance.ShowCargoResults(cargoTransferData.Item2);
                
                break;
            default:
                DatabaseResults.Instance.HideResults();
                
                queryOutput = "Invalid table. Available tables are: arrivals, departures, cargo, spacecraft, stations";
                break;
        }
        
        return queryOutput;
    }
}
