using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSpawn : MonoBehaviour
{
    public GameObject tank;
    int spawnChance = ( 20  *60); //determines the chance each frame that a tank will be spawned 

    
    void Update()
    {
        if(Random.Range(0, spawnChance) == 1)
        {
            Instantiate(tank, transform.position, Quaternion.identity);
        }
    }
}
