using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollision : MonoBehaviour
{
    public GameObject rubbleEffect;
    public int sinkDistance;

    

    void OnTriggerEnter(Collider hand)
    {
        if(hand.tag == "hand")
        {
            if(gameObject.tag == "skyscraper")
            {
                SkyscraperHit(hand.transform.position);
            }
            else if (gameObject.tag == "house")
            {
                HouseDestroy();
            }
        }
    }

    //function called when skyscraper is hit with hand
    void SkyscraperHit(Vector3 handPosition)
    {
        Instantiate(rubbleEffect, handPosition, Quaternion.identity);


        /////
        //make building go down
        /////

        if(transform.position.y == 0)
            SkyscraperDestroy();
    }

    //function called when skyscraper is destroyed
    void SkyscraperDestroy()
    {
        Destroy(gameObject);
    }

    //function for when house is hit with hand
    void HouseDestroy()
    {
        Instantiate(rubbleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
