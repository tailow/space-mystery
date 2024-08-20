public class MessagesCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        return "There is a suspected terrorist.\n" +
               "They departed station Theta at time 50.\n" +
               "Type 'help' to see a list of commands.";
    }
}
