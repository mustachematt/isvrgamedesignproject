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

    private bool isPlaying;
    private AudioSource source;
    private Vector3 walkVector;
    private Vector3 velocity;
    private CharacterController characterController;


    private void Start()
    {
        isPlaying = false;
        walkVector = Vector3.zero;
        source = GetComponent<AudioSource>();
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

        // the sound should not play initially as the player is not moving
        // if the player starts moving, 
        //     play the sound and let it loop
        //     Play() should only be called once.
        //     After this call, set isPlaying to true to prevent future calls while the player is still moving
        // if the player stops moving
        //     set isPlaying to false to allow us to start playing the sound again once the player is moving again
        //     stop looping the sound to let it stop naturally

        if (velocity.magnitude > 1f && !isPlaying)
        {
            source.loop = true;
            source.Play();
            isPlaying = true;
        }
        else if (velocity.magnitude <= 1f && isPlaying)
        {
            source.loop = false;
            isPlaying = false;
        }

        walkVector = Vector3.zero; // reset the walk vector

        // adjust the position of the capsule to be where the player is in real space
        Vector3 cameraPositionXZ = new Vector3(vrCamera.transform.position.x, 0, vrCamera.transform.position.z);
        //Vector3 capsulePositionXZ = new Vector3(transform.position.x, 0, transform.position.z);

        //characterController.center = (cameraPositionXZ - capsulePositionXZ) / 4.5f;
    }
}