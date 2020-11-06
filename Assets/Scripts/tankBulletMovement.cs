using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankBulletMovement : MonoBehaviour
{
    float increment = 150;
    Vector3 moveUpTarget = new Vector3( 0, 8, 0);
    int bulletDamage = 2;

    public GameObject explosion;

    Vector3 startPos;
    Vector3 playerPos;
    GameObject player;
    Vector3 change;

    void Start()
    {
        startPos = GetComponent<Transform>().position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position + moveUpTarget;
        change = (playerPos - startPos) / increment;
    }


    void FixedUpdate()
    {
        transform.position += change;

        if(Vector3.Distance(transform.position, startPos) > 40)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "hand")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "skyscraper")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
