using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public string TerroristSpacecraftName;
    public string TerroristDestinationStation;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetInt("volume", 50));
    }

    public void EndGame()
    {
        Terminal.Instance.DisplayOutput("\nThat information seems correct. We'll get back to you once we have investigated that spacecraft.\n");
        
        Terminal.Instance.DisplayOutput(new CreditsCommand().Execute(Array.Empty<string>()));
        
        Terminal.Instance.DisplayOutput("\nCongratulations for completing the game! Feedback is greatly appreciated.");
    }

    public void SetVolume(int volume)
    {
        FMOD.Studio.Bus master = FMODUnity.RuntimeManager.GetBus("bus:/");

        master.setVolume(volume / 100f);
        
        PlayerPrefs.SetInt("volume", volume);
    }
}
