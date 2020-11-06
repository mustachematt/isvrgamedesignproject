using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliBladeRotation : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;

    public float curSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, curSpeed * Time.deltaTime, 0.0f, Space.Self);

        curSpeed += acceleration;

        if (curSpeed > maxSpeed)
            curSpeed = maxSpeed;
    }
}
