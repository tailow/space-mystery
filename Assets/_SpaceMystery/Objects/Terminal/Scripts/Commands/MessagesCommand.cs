public class MessagesCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        return "skibidi\n" +
               "there is a terrorist on the loose\n" +
               "left station Theta at time 10\n" +
               "type 'help' to see a list of commands";
    }
}
