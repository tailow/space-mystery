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

                queryOutput += "NAME : OWNER : TYPE : MAXFUEL : MAXLOAD : CRUISESPEED : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (Spacecraft spacecraft in spacecraftData)
                {
                    queryOutput += $"{spacecraft.name} : {spacecraft.owner} : {spacecraft.type} : {spacecraft.maxFuel} :" +
                                   $" {spacecraft.maxLoad} : {spacecraft.cruiseSpeed} : {spacecraft.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            case "stations":
                IEnumerable<Station> stationData = dataService.GetStations(args.Skip(2).ToArray());
                
                queryOutput += "ID : NAME : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (Station station in stationData)
                {
                    queryOutput += $"{station.id} : {station.name} : {station.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            case "arrivals":
                IEnumerable<Arrival> arrivalData = dataService.GetArrivals(args.Skip(2).ToArray());
                
                queryOutput += "SPACECRAFT : STATION : TIME : RESERVATION TIME : STATUS : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (Arrival arrival in arrivalData)
                {
                    queryOutput += $"{arrival.spacecraftName} : {arrival.stationId} : {arrival.arrivalTime} : {arrival.reservationTime} :" +
                                   $" {arrival.statusCode} : {arrival.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            case "departures":
                IEnumerable<Departure> departureData = dataService.GetDepartures(args.Skip(2).ToArray());
                
                queryOutput += "SPACECRAFT : STATION : DESTINATION : DISTANCE : TIME : STATUS : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (Departure departure in departureData)
                {
                    queryOutput += $"{departure.spacecraftName} : {departure.departureStationId} : {departure.destinationStationId} :" +
                                   $" {departure.destinationDistance} : {departure.departureTime} : {departure.statusCode} : {departure.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            case "cargo":
                IEnumerable<CargoTransfer> cargoTransferData = dataService.GetCargoTransfers(args.Skip(2).ToArray());
                
                queryOutput += "ID : STATION : SOURCE : DESTINATION : CONTENT : WEIGHT : TIME : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (CargoTransfer cargoTransfer in cargoTransferData)
                {
                    queryOutput += $"{cargoTransfer.cargoId} : {cargoTransfer.stationId} : {cargoTransfer.startSpacecraftName} : {cargoTransfer.destinationSpacecraftName} : " +
                                   $"{cargoTransfer.cargoContent} : {cargoTransfer.cargoWeight} : {cargoTransfer.transferTime} : {cargoTransfer.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            default:
                queryOutput = "Invalid table. Available tables are: arrivals, departures, cargo, spacecraft, stations";
                break;
        }
        
        return queryOutput;
    }
}
