using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleThrow : MonoBehaviour
{

    public GameObject explosion;
    public float neededSpeed;
    Velocity vel;
    bool hitBuilding = false;

    void Start()
    {
        vel = GetComponent<Velocity>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (CheckTag(other.gameObject.tag) == true)
        {

            //***************
            //add building damage here

            //***************

            if (vel.speed >= neededSpeed)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject); //maybe move outside if statement - fix later
            }
            else { hitBuilding = true; }
        }
        if (other.gameObject.tag == "ground" && hitBuilding == true)
        {
            //small explosion
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
        else
        {
            return false;
        }
    }
    
}
