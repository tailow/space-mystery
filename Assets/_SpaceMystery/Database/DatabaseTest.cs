using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabaseTest : MonoBehaviour
{
    private void Start()
    {
        DataService dataService = new DataService();

        IEnumerable<SpacecraftQuery> spacecraftResults = dataService.GetSpacecraftData();

        foreach (SpacecraftQuery spacecraft in spacecraftResults)
        {
            Debug.Log(spacecraft.name + " " + spacecraft.owner + " " + spacecraft.type + " " + spacecraft.maxFuel);
        }
    }
}
