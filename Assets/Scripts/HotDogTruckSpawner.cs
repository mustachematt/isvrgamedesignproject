using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogTruckSpawner : MonoBehaviour
{
    static int onePerSeconds = 30;     // had it at 30

    GlobalCounterScript spawnLimit;

    public GameObject hotDogTruck;
    int spawnChance = (onePerSeconds * 60); //determines the chance each frame that a tank will be spawned 


    void Start()
    {
        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();
    }

    void Update()
    {
        if (spawnLimit.hotDogTruckCounter > 0) // Limit number of tanks that spawn.
        {
            if (Random.Range(0, spawnChance) == 1)
            {
                Instantiate(hotDogTruck, transform.position, Quaternion.identity);
                spawnLimit.hotDogTruckCounter--;
            }
        }
    }
}
