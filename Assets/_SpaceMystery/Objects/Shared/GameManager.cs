using System;

public class GameManager : Singleton<GameManager>
{
    public string TerroristSpacecraftName;
    public string TerroristDestinationStation;

    public void EndGame()
    {
        Terminal.Instance.DisplayOutput("\nThat information seems correct. We'll get back to you once we have investigated that spacecraft.\n");
        
        Terminal.Instance.DisplayOutput(new CreditsCommand().Execute(Array.Empty<string>()));
    }
}
