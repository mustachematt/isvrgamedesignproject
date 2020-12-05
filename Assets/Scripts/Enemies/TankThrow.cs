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
    void Awake()
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
        switch (myTag)
        {
            case "skyscraper":
            case "building":
            case "house":
            case "gas station":
            case "vehicle":
            case "helicopter":
            case "militaryBase":
                return true;
            default:
                return false;
        }
    }

    void tankDestroyed()
    {
        spawnLimit.tankCounter++;
        Destroy(gameObject);
    }
}
