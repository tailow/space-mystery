public class HelpCommand : Command
{
    public override string Execute(string[] args)
    {
        return "Available commands:\n" +
               "    * help\n" +
               "        - Shows all available commands\n" +
               "    * exit\n" +
               "        - Exits the game\n" +
               "    * search (table) [arg1] [arg2]\n" +
               "        - Searches specified table in the database with optional arguments\n" +
               "        - Tables: arrivals, departures, spacecraft, stations, cargo\n" +
               "        - Example: search arrivals time>46 time<58 station=EFKU\n" +
               "    * alert (spacecraft) (destination station)\n" +
               "        - Alerts the officials to a potential threat\n" +
               "        - Example: alert ARX-120 EFKU\n";
    }
}
