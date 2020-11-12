using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject smoke;

    public GameObject tank;
    private GameObject bullet;

    int timeBetweenShots = 300;

    int currentTime = 100;

    public bool damageIndicatorOn = false;

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
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.SetParent(tank.transform);
            currentTime = 0;
        }
    }

    void Update()
    {
        if (damageIndicatorOn)
        {
            Register();
            damageIndicatorOn = false;
        }
    }

    void Register()
    {
        if (!DamageIndicatorSystem.CheckIfObjectInSight(this.transform))
            DamageIndicatorSystem.CreateIndicator(this.transform);
    }
}
