using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAddPoints : MonoBehaviour
{
    GameObject globalCounter;

    int skyScraperPoints = 500;
    int mediumBuildingPoints = 300;
    int housePoints = 100;
    int gasStationPoints = 500;

    int myPointValue = 0;
    
    void Start()
    {
        if (tag == "skyscraper")
        {
            myPointValue = skyScraperPoints;
        }
        else if(tag == "building")
        {
            myPointValue = mediumBuildingPoints;
        }
        else if (tag == "house")
        {
            myPointValue = housePoints;
        }
        else if (tag == "gas station")
        {
            myPointValue = gasStationPoints;
        }

        globalCounter = GameObject.Find("GlobalCounter");
        if (globalCounter != null) // if it can't be found
            globalCounter.GetComponent<GlobalCounterScript>().totalPercentPoints += myPointValue;

    }

    void OnDestroy()
    {
        if (globalCounter != null)
        {
            globalCounter.GetComponent<GlobalCounterScript>().currentPercentPoints += myPointValue;
            globalCounter.GetComponent<GlobalCounterScript>().currentPoints += myPointValue;
        }
    }
}
