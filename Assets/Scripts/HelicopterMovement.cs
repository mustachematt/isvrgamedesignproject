using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HelicopterMovement : MonoBehaviour
{
    Transform player;

    NavMeshAgent nav;

    public HeliBladeRotation bladeSpeed;

    public GameObject[] missleSpawn;
    public GameObject missle;

    public int playerRadius;

    bool liftOff = true;
    bool chase = false;
    bool shoot = false;

    public int shotDelay;
    int shotDelayReset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;

        shotDelay = shotDelay * 60;
        shotDelayReset = shotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (bladeSpeed.curSpeed >= 100f)
        {
            HelicopterAI();
        }

    }

    void HelicopterAI()
    {
        if (liftOff)
        {
            transform.position += new Vector3(0, 1f * Time.deltaTime, 0);
            if (transform.position.y > 34)
            {
                nav.enabled = true;
                toggleAttack(0);
            }
        }

        if (shoot)
        {
            nav.destination = transform.position;

            transform.LookAt(player);

            if ((Vector3.Distance(player.position, transform.position) > playerRadius))
            {
                toggleAttack(0);
            }

            if (shotDelay <= 0)
            {
                int spawnSelect = Random.Range(0, 4);

                Instantiate(missle, missleSpawn[spawnSelect].transform.position, transform.rotation);

                shotDelay = shotDelayReset;
            }

            shotDelay--;
        }

        if (chase)
        {
            nav.destination = new Vector3(player.position.x, transform.position.y, player.position.z);

            transform.LookAt(player);

            if ((Vector3.Distance(player.position, transform.position) < playerRadius))
            {
                toggleAttack(1);
            }
        }
    }

    void toggleAttack(int i)
    {
        switch (i)
        {
            case 0: // Chase
                liftOff = false;
                chase = true;
                shoot = false;
                break;

            case 1: // attack
                liftOff = false;
                chase = false;
                shoot = true;
                break;
        }
    }
}
