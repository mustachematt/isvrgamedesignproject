using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bullet;

    int timeBetweenShots = 300;

    int currentTime = 0;


    void Start()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        currentTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime++;

        if(currentTime >= timeBetweenShots)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            currentTime = 0;
        }
    }
}
