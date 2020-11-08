using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HelicopterMissleBehavior : MonoBehaviour
{
    Rigidbody missleRigidbody;
    public float missleSpeed;

    AudioSource missleSound;
    public AudioClip missleLaunch;

    public GameObject explosion;

    GlobalCounterScript health;

    // Start is called before the first frame update
    void Start()
    {
        missleSound = GetComponent<AudioSource>();
        missleRigidbody = GetComponent<Rigidbody>();
        health = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();

        missleSound.PlayOneShot(missleLaunch, 0.7F);
    }

    // Update is called once per frame
    void Update()
    {
        missleRigidbody.velocity = transform.forward * missleSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "body")
            missleDamage();
        else
            destroyMissle();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            destroyMissle();
        }
        else
            destroyMissle();
    }

    void destroyMissle()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void missleDamage()
    {
        health.TakeDamage(5);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
