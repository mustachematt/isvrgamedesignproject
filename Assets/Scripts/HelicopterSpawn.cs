using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterSpawn : MonoBehaviour
{
    public GameObject helicopter;

    public int spawnChance;
    public int delayRange;
    public int delayReset;
    // Start is called before the first frame update
    void Start()
    {
        delayReset = delayRange;
        delayRange = Random.Range(delayRange, delayRange + 11) * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayRange <= 0)
        {
            if (Random.Range(1, spawnChance + 1) == 1)
            {
                Instantiate(helicopter, transform.position, Quaternion.identity);
                delayRange = delayReset;
                delayRange = Random.Range(delayRange, delayRange + 11) * 60;
            }
        }
        delayRange--;
    }
}