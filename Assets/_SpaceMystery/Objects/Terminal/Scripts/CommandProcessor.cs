using System.Collections.Generic;

public class CommandProcessor
{
    private Dictionary<string, Command> commands = new Dictionary<string, Command>();

    public void Initialize()
    {
        commands.Add("help", new HelpCommand());
        commands.Add("exit", new ExitCommand());
        commands.Add("quit", new ExitCommand());
        commands.Add("search", new SearchCommand());
        commands.Add("alert", new AlertCommand());
        commands.Add("time", new TimeCommand());
        commands.Add("messages", new MessagesCommand());
        commands.Add("back", new BackCommand());
    }

    public string ProcessCommand(string input)
    {
        string[] splitInput = input.Split(' ');
        string commandName = splitInput[0].ToLower();

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