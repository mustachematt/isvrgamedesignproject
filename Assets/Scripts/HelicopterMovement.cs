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
    public GameObject misslePrefab;

    public GameObject helicopter;
    private GameObject missle;

    public int playerRadius;

    bool liftOff = true;
    bool chase = false;
    bool shoot = false;

    public float shotDelay;
    float shotDelayReset;

    Velocity leftHandVelocity;
    Velocity rightHandVelocity;

    public GameObject explosionLarge;

    GlobalCounterScript spawnLimit;

    public bool damageIndicatorOn = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();

        // For VR headset uncomment this 
        leftHandVelocity = GameObject.Find("LeftHandTrigger").GetComponent<Velocity>();
        rightHandVelocity = GameObject.Find("RightHandTrigger").GetComponent<Velocity>();

        // For testing without VR headset Uncomment this
        //leftHandVelocity = GameObject.Find("TempHandLeft").GetComponent<Velocity>();
        //rightHandVelocity = GameObject.Find("TempHandRight").GetComponent<Velocity>();

        nav.enabled = false;

        shotDelayReset = shotDelay;
        shotDelay = Random.Range(shotDelay, shotDelay + 3.0f) * 60f;
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

                missle = Instantiate(misslePrefab, missleSpawn[spawnSelect].transform.position, transform.rotation);
                missle.transform.SetParent(helicopter.transform);


                shotDelay = shotDelayReset;
                shotDelay = Random.Range(shotDelay, shotDelay + 3.0f) * 60f;
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

        if (damageIndicatorOn)
        {
            Register();
            damageIndicatorOn = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "hand" && (leftHandVelocity.speed >= 4 || rightHandVelocity.speed >= 4)) || other.tag == "explosion")
        {
            helicopterDestroyed();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "vehicle" || other.gameObject.tag == "tank")
        {
            helicopterDestroyed();
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

    void helicopterDestroyed()
    {
        spawnLimit.helicopterCounter++;
        Instantiate(explosionLarge, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Register()
    {
        if (!DamageIndicatorSystem.CheckIfObjectInSight(this.transform))
            DamageIndicatorSystem.CreateIndicator(this.transform);
    }
}
