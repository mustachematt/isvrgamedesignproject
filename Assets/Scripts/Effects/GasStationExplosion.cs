using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GasStationExplosion : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;

    public Velocity velocityCheck1;
    public Velocity velocityCheck2;

    public GameObject explosionEffect;
    public GameObject fireEffect;
    public GameObject smokeEffect;

    Vector3 fireLocation;
    Vector3 explosionLocation;

    public bool fireOn = false;

    // Start is called before the first frame update
    void Start()
    {
        fireLocation = new Vector3(transform.position.x, 20f, transform.position.z);
        explosionLocation = new Vector3(transform.position.x, 22f, transform.position.z);
    }


    void OnTriggerEnter(Collider hand)
    {
        if (hand.tag == "hand" && (velocityCheck1.speed >= 4 || velocityCheck2.speed >= 4))
        {
            destroyGasStation();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "vehicle")
        {
            destroyGasStation();
        }
    }

    void destroyGasStation()
    {
        spawnFire();
        Instantiate(explosionEffect, explosionLocation, Quaternion.Euler(90,0,0));
        Destroy(gameObject);
    }

    void spawnFire()
    {
        int fireSpawnChance = Random.Range(0, 11);

        if (fireSpawnChance == 10)
        {
            if (fireOn == false)
            {
                Instantiate(fireEffect, fireLocation, Quaternion.identity);
                Instantiate(smokeEffect, fireLocation, Quaternion.identity);
                fireOn = true;
            }
        }
    }
}
