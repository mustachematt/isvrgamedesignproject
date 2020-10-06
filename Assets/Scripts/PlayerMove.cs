using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 8f;
    public GameObject vrCamera;
    public SteamVR_Action_Vector2 walk;
    public SteamVR_Input_Sources rightHand;

    private Vector3 walkVector;
    private Vector3 velocity;
    private CharacterController characterController;


    private void Start()
    {
        walkVector = Vector3.zero;
        velocity = Vector3.forward; // to fix the camera issue at the start
        characterController = GetComponent<CharacterController>();
        walk.AddOnAxisListener(GetWalkDirection, rightHand);
    }


    private void GetWalkDirection(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        // convert the vector from the thumb position on the controller to 3d
        Vector3 thumbVector = new Vector3(walk.axis.x, 0, walk.axis.y);

        // get the angle of the camera relative to the forward position
        float cameraAngle = Vector3.SignedAngle(Vector3.forward, vrCamera.transform.forward, Vector3.up);

        // rotate the thumb vector that many degrees to get the walk vector
        walkVector = Quaternion.AngleAxis(cameraAngle, transform.up) * thumbVector;
    }


    private void LateUpdate()
    {
        // for movement smoothing
        velocity = Vector3.Lerp(velocity, walkVector * walkSpeed, 3 * Time.deltaTime);

        // move the player in that direction
        characterController.SimpleMove(velocity);
        walkVector = Vector3.zero; // reset
    }
}