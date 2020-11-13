using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSpawn : MonoBehaviour
{
    static int onePerSeconds = 90;     //had it at 90

    GlobalCounterScript spawnLimit;

    public GameObject tank;
    int spawnChance = (onePerSeconds  *60); //determines the chance each frame that a tank will be spawned 


    void Start()
    {
        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();
    }

    void Update()
    {
        if (spawnLimit.tankCounter > 0) // Limit number of tanks that spawn.
        {
            if (Random.Range(0, spawnChance) == 1)
            {
                Instantiate(tank, transform.position, Quaternion.identity);
                spawnLimit.tankCounter--;
            }
        }
    }
}
