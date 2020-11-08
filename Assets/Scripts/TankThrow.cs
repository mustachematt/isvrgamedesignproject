using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TankThrow : MonoBehaviour
{
    public GameObject explosionLarge;
    public GameObject explosionSmall;

    AudioSource stopEngine;

    public float neededSpeed;
    Velocity vel;
    bool hitBuilding = false;

    GlobalCounterScript spawnLimit;

    // Start is called before the first frame update
    void Start()
    {
        vel = GetComponent<Velocity>();
        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();
        stopEngine = GetComponent<AudioSource>();

        stopEngine.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "explosion")
        {
            Instantiate(explosionSmall, transform.position, Quaternion.identity);
            tankDestroyed();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (CheckTag(other.gameObject.tag) == true)
        {
            if (vel.speed >= neededSpeed)
            {
                Instantiate(explosionLarge, transform.position, Quaternion.identity);
                tankDestroyed();
            }
            else { hitBuilding = true; }
        }
        if (other.gameObject.tag == "ground" && hitBuilding == true)
        {
            Instantiate(explosionSmall, transform.position, Quaternion.identity);
            tankDestroyed();
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
        else
        {
            return false;
        }
    }

void tankDestroyed()
    {
        spawnLimit.tankCounter++;
        Destroy(gameObject);
    }
}
