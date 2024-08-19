using System;

public class VolumeCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();

        if (int.TryParse(args[1], out int volume))
        {
            // TODO: Set volume
            volume = Math.Clamp(volume, 0, 100);
            
            return $"Set volume to {volume}.";
        }

        else
        {
            return "You must provide a volume number between 0-100.";
        }
    }
}
