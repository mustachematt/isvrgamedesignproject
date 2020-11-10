using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HelicopterSpawn : MonoBehaviour
{
    static int onePerSeconds = 60;     // Had it at 60

    GlobalCounterScript spawnLimit;

    public GameObject helicopter;
    int spawnChance = (onePerSeconds * 60); // Determines the chance each frame that a helicopter will be spawned 

    public bool spawnDelay = false;

    int timer = 300;

    void Start()
    {
        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();
    }

    void Update()
    {
        if (spawnLimit.helicopterCounter > 0 && !spawnDelay) // Limit number of tanks that spawn.
        {
            if (Random.Range(0, spawnChance) == 1)
            {
                Instantiate(helicopter, transform.position, Quaternion.identity);
                spawnLimit.helicopterCounter--;
                spawnDelay = true;
            }
        }
        if (spawnDelay)
        {
            timer--;
            if (timer <= 0)
            {
                spawnDelay = false;
                timer = 300;
            }
        }
    }
}