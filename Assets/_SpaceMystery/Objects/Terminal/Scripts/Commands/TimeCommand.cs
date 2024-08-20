public class TimeCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        return "Earth time: 30/08/2078 12:01\n" +
               "Universal time: 60\n";
    }
}
