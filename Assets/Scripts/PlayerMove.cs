using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMove : MonoBehaviour
{
    public GameObject vrCamera;
    public SteamVR_Action_Vector2 walk;
    public SteamVR_Input_Sources rightHand;
    public float walkSpeed = 20f;


    private void Start()
    {
        walk.AddOnAxisListener(GetWalkDirection, rightHand);
    }


    public void GetWalkDirection(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        // convert the vector from the thumb position on the controller to 3d
        Vector3 thumbVector = new Vector3(walk.axis.x, 0, walk.axis.y);

        // get the angle of the camera relative to the forward position
        float cameraAngle = Vector3.SignedAngle(Vector3.forward, vrCamera.transform.forward, Vector3.up);

        // rotate the thumb vector that many degrees to get the walk vector
        Vector3 walkVector = Quaternion.AngleAxis(cameraAngle, transform.up) * thumbVector;
        
        // move that direction
        GetComponent<Rigidbody>().AddForce(walkVector * walkSpeed);
    }
}
