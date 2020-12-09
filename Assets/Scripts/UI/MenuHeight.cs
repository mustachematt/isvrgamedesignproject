using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHeight : MonoBehaviour
{
    public GameObject vrCamera;


    // have the menu follow the height of
    // the player's head
    private void Update()
    {
        // if the camera is more than 6 units higher than the menu
        //     move the menu up by 2 units
        // if the camera is less than 2 units higher than the menu
        //     move the menu down by 2 units
        if (vrCamera.transform.position.y - transform.position.y > 6)
        {
            Vector3 menuPosition = new Vector3(
                transform.position.x,
                transform.position.y + 2,
                transform.position.z
            );
            transform.position = menuPosition;
        }
        if (vrCamera.transform.position.y - transform.position.y < 2)
        {
            Vector3 menuPosition = new Vector3(
                transform.position.x,
                transform.position.y - 2,
                transform.position.z
            );
            transform.position = menuPosition;
        }
    }
}
