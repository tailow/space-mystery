public class MessagesCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        return "There is a suspected terrorist.\n" +
               "They departed station Theta at time 1150.\n" +
               "Information regarding the terrorist's past whereabouts is available.\n" +
               "Track their activities and alert us as soon as you can determine their next step.\n" +
               "Note that they might have cargo containing weapons of mass destruction.\n\n" +
               "The database display only shows the first 100 results, so narrow down your searches with search options.\n\n" +
               "Type 'help' to see a list of commands.";
    }
}
