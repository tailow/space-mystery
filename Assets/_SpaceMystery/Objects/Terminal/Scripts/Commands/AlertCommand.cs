using UnityEngine;

public class AlertCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        string spacecraftName = args[1];
        string stationId = args[2];

        if (spacecraftName != GameManager.Instance.TerroristSpacecraftName.ToLower())
        {
            Debug.Log(spacecraftName);
            
            return "There doesn't seem to be anything suspicious regarding that spacecraft.";
        }
        
        else if (stationId != GameManager.Instance.TerroristDestinationStation.ToLower())
        {
            return "There doesn't seem to be any suspicious spacecraft entering that station.";
        }
        
        else
        {
            // WIN
            return "That information seems correct. We'll get back to you once we have investigated that spacecraft.";
        }
    }
}
