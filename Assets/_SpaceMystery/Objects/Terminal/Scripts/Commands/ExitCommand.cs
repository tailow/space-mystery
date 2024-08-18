using UnityEngine;

public class ExitCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        Application.Quit();
        return "Exiting game...";
    }
}
