using System.Collections.Generic;

public class SearchCommand : Command
{
    public override string Execute(string[] args)
    {
        if (args.Length <= 1) return "Please input the table to be searched.";
        
        DataService dataService = new DataService();
        
        string queryOutput = "";
        
        switch (args[1])
        {
            case "spacecraft":
                IEnumerable<SpacecraftQuery> spacecraftData = dataService.GetSpacecraftData();

                queryOutput += "NAME : OWNER : MAX FUEL : TYPE\n" +
                               "------------------------------------------------\n";
                
                foreach (SpacecraftQuery spacecraft in spacecraftData)
                {
                    queryOutput += $"{spacecraft.name} : {spacecraft.owner} : {spacecraft.maxFuel} : {spacecraft.type}\n" +
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
