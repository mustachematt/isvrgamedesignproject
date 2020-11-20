using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDifficulty : MonoBehaviour
{

    public int whichAmI;   // which of the two turrets - #1 or #2

    // Start is called before the first frame update
    void Start()
    {
        int currentDifficulty = GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().currentDifficulty;

        if (currentDifficulty == 1)
        {
            gameObject.SetActive(false); //no turrent on easy
        }
        else if(currentDifficulty == 2 || currentDifficulty == 0)
        {
            if(whichAmI != 1)
                gameObject.SetActive(false); //turn off second turret
        }
        else // difficult or god mode
        {
            gameObject.SetActive(true); //both on
        }
    }
}
