public class CreditsCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();

        return "This game was developed by Karhut Games.\n\n" +
               "Audio Engine: FMOD Studio by Firelight Technologies Pty Ltd.\n\n" +
               "Assets:\n" +
               "    - 3D Scifi Starter Kit (Creepy Cat)\n" +
               "    - Federation Corvette F3 and Free SF Fighter (CGPitbull)\n" +
               "    - Office pack - Free (nappin)\n" +
               "    - Destroyable Retro CRT Monitor Prop (Pekdata)";
    }
}
