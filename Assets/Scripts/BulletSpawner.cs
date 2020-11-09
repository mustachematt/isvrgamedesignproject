using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public GameObject smoke;

    int timeBetweenShots = 300;

    int currentTime = 100;


    void Start()
    {
        //Instantiate(bullet, transform.position, transform.rotation);
        currentTime = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime++;

        if(currentTime >= timeBetweenShots)
        {
            Instantiate(smoke, transform.position, transform.rotation);
            Instantiate(bullet, transform.position, transform.rotation);
            currentTime = 0;
        }
    }
}
