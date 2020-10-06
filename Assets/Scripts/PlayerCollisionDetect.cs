using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetect : MonoBehaviour
{
    public bool isColliding;


    private bool isStructre(Collider other)
    {
        return
            other.tag == "building" ||
            other.tag == "skyscraper" ||
            other.tag == "gas station" ||
            other.tag == "house";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isStructre(other))
            isColliding = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (isStructre(other))
            isColliding = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (isStructre(other))
            isColliding = false;
    }
}
