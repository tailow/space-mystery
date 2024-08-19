public class BackCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();

        return "";
    }
}
