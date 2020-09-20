using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMove : MonoBehaviour
{
    public SteamVR_Action_Vector2 walk;
    public SteamVR_Input_Sources handType;
    public float walkSpeed = 2f;

    private void Start()
    {
        walk.AddOnAxisListener(WalkDirection, handType);
    }

    public void WalkDirection(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        Debug.Log(walk.axis);
        transform.position = new Vector3(transform.position.x + (walk.axis.x * walkSpeed * Time.deltaTime),
            transform.position.y,
            transform.position.z + (walk.axis.y * walkSpeed * Time.deltaTime));
    }
}
