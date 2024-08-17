public class HelpCommand : Command
{
    public override string Execute(string[] args)
    {
        return "Available commands: help, exit, search";
    }
}
