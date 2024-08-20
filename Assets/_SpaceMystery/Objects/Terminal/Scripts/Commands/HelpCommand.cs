public class HelpCommand : Command
{
    public override string Execute(string[] args)
    {
        DatabaseResults.Instance.HideResults();
        
        return "Available commands:\n" +
               "    * help\n" +
               "        - Shows all available commands\n" +
               "    * exit\n" +
               "        - Exits the game\n" +
               "    * search (table) [option 1] [option 2]...\n" +
               "        - Searches specified table in the database with optional search options\n" +
               "        - Tables: arrivals, departures, spacecraft, stations, cargo\n" +
               "        - Example: search arrivals time>46 time<58 station=Sol\n" +
               "    * alert (spacecraft) (destination station)\n" +
               "        - Alerts the officials to a potential threat\n" +
               "        - Example: alert ARX-120 Sol\n" +
               "    * time\n" +
               "        - Shows the current time\n" +
               "    * messages\n" +
               "        - Shows latest messages\n" +
               "    * back\n" +
               "        - Closes the database display\n" +
               "    * credits\n" +
               "    * volume (0-100)\n" +
               "        - Sets the in-game volume to a value between 0 and 100 (default is 50).";
    }
}
