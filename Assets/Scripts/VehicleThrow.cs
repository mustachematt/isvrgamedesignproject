using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleThrow : MonoBehaviour
{

    public GameObject explosionLarge;
    public GameObject explosionSmall;
    public float neededSpeed;
    Velocity vel;
    bool hitBuilding = false;

    void Start()
    {
        vel = GetComponent<Velocity>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "explosion")
        {
            Instantiate(explosionSmall, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (CheckTag(other.gameObject.tag) == true)
        {
            if (vel.speed >= neededSpeed)
            {
                Instantiate(explosionLarge, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else { hitBuilding = true; }
        }
        if (other.gameObject.tag == "ground" && hitBuilding == true)
        {
            Instantiate(explosionSmall, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    bool CheckTag(string myTag)
    {
        if (myTag == "skyscraper")
        {
            return true;
        }
        else if (myTag == "building")
        {
            return true;
        }
        else if (myTag == "house")
        {
            return true;
        }
        else if (myTag == "gas station")
        {
            return true;
        }
        else if (myTag == "vehicle")
        {
            return true;
        }
        else if (myTag == "helicopter")
        {
            return true;
        }
        else if (myTag == "militaryBase")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
