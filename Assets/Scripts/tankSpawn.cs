using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSpawn : MonoBehaviour
{
    static int onePerSeconds = 20;     //had it at 20

    public GameObject tank;
    int spawnChance = (onePerSeconds  *60); //determines the chance each frame that a tank will be spawned 

    
    void Update()
    {
        if(Random.Range(0, spawnChance) == 1)
        {
            Instantiate(tank, transform.position, Quaternion.identity);
        }
    }
}
