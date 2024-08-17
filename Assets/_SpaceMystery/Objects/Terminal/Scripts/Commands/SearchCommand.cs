using System.Collections.Generic;

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
                IEnumerable<Spacecraft> spacecraftData = dataService.GetSpacecraft();

                queryOutput += "NAME : OWNER : MAX FUEL : TYPE\n" +
                               "------------------------------------------------\n";
                
                foreach (Spacecraft spacecraft in spacecraftData)
                {
                    queryOutput += $"{spacecraft.name} : {spacecraft.owner} : {spacecraft.maxFuel} : {spacecraft.type}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            case "stations":
                IEnumerable<Station> stationData = dataService.GetStations();
                
                queryOutput += "IDENTIFIER : NAME : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (Station station in stationData)
                {
                    queryOutput += $"{station.id} : {station.name} : {station.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            case "arrivals":
                IEnumerable<Arrival> arrivalData = dataService.GetArrivals();
                
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
                IEnumerable<Departure> departureData = dataService.GetDepartures();
                
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
                IEnumerable<CargoTransfer> cargoTransferData = dataService.GetCargoTransfers();
                
                queryOutput += "IDENTIFIER : STATION : SOURCE : DESTINATION : CONTENT : WEIGHT : TIME : NOTES\n" +
                               "------------------------------------------------\n";
                
                foreach (CargoTransfer cargoTransfer in cargoTransferData)
                {
                    queryOutput += $"{cargoTransfer.cargoId} : {cargoTransfer.stationId} : {cargoTransfer.startSpacecraftName} : {cargoTransfer.destinationSpacecraftName} : " +
                                   $"{cargoTransfer.cargoContent} : {cargoTransfer.cargoWeight} : {cargoTransfer.transferTime} : {cargoTransfer.notes}\n" +
                                   "------------------------------------------------\n";
                }
                
                break;
            default:
                queryOutput = "Invalid table";
                break;
        }
        
        return queryOutput;
    }
}
