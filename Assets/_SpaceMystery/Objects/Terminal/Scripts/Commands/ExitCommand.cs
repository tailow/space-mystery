using UnityEngine;

public class ExitCommand : Command
{
    public override string Execute(string[] args)
    {
        Application.Quit();
        return "Exiting game...";
    }
}
