using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HelicopterMissleBehavior : MonoBehaviour
{
    Rigidbody missleRigidbody;
    public float missleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        missleRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        missleRigidbody.velocity = transform.forward * missleSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "helicopter")
            Destroy(gameObject);
    }
}
