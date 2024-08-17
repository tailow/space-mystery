using System.Collections.Generic;

public class CommandProcessor
{
    private Dictionary<string, Command> commands = new Dictionary<string, Command>();

    public void Initialize()
    {
        commands.Add("help", new HelpCommand());
        commands.Add("exit", new ExitCommand());
        commands.Add("search", new SearchCommand());
    }

    public string ProcessCommand(string input)
    {
        string[] splitInput = input.ToLower().Split(' ');
        string commandName = splitInput[0];

        if (commands.TryGetValue(commandName, out Command command))
        {
            return command.Execute(splitInput);
        }
        else
        {
            return "Unknown command. Type 'help' for a list of commands.";
        }
    }
}