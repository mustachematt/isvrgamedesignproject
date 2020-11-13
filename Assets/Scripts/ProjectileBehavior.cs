using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Rigidbody missleRigidbody;
    public float missleSpeed;

    AudioSource missleSound;
    public AudioClip missleLaunch;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        missleSound = GetComponent<AudioSource>();
        missleRigidbody = GetComponent<Rigidbody>();

        missleSound.PlayOneShot(missleLaunch, 0.7F);
    }

    // Update is called once per frame
    void Update()
    {
        missleRigidbody.velocity = transform.forward * missleSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        destroyMissle();
    }

    void OnTriggerEnter(Collider other)
    {
        destroyMissle();
    }

    void destroyMissle()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
