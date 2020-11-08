using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public class TankMovement : MonoBehaviour
{

    public GameObject bulletMaker;

    Vector3 goTo;

    Transform player;

    Transform goal1;
    Transform goal2;
    Transform goal3;
    Transform goal4;
    Transform goal5;
    Transform goal6;
    Transform goal7;
    Transform goal8;
    Transform goal9;

    NavMeshAgent nav1;

    int pickGoal;
    int goalDistance = 10;
    public int playerRadius = 20;  //was 30, changed to 20, and helicopter distance is 35 now.

    bool patrol = true;
    bool shoot = false;
    bool chase = false;

    Velocity leftHandVelocity;
    Velocity rightHandVelocity;

    public GameObject explosionLarge;

    GlobalCounterScript spawnLimit;
    TankMovement tankMovementScript;
    TankThrow tankThrowScript;
    Throwable VRHand;

    void Start()
    {
        goal1 = GameObject.Find("tankGoal1").transform;
        goal2 = GameObject.Find("tankGoal2").transform;
        goal3 = GameObject.Find("tankGoal3").transform;
        goal4 = GameObject.Find("tankGoal4").transform;
        goal5 = GameObject.Find("tankGoal5").transform;
        goal6 = GameObject.Find("tankGoal6").transform;
        goal7 = GameObject.Find("tankGoal7").transform;
        goal8 = GameObject.Find("tankGoal8").transform;
        goal9 = GameObject.Find("tankGoal9").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;  //change to actual player obj when ready

        nav1 = GetComponent<NavMeshAgent>();

        // For VR headset uncomment this 
        //leftHandVelocity = GameObject.Find("LeftHandTrigger").GetComponent<Velocity>();
        //rightHandVelocity = GameObject.Find("RightHandTrigger").GetComponent<Velocity>();

        // For testing without VR headset Uncomment this
        leftHandVelocity = GameObject.Find("TempHandLeft").GetComponent<Velocity>();
        rightHandVelocity = GameObject.Find("TempHandRight").GetComponent<Velocity>();

        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();

        tankMovementScript = GetComponent<TankMovement>();
        tankThrowScript = GetComponent<TankThrow>();
        VRHand = GetComponent<Throwable>();

        ChooseLocation();

        bulletMaker.SetActive(false);
    }
    
    void Update()
    {
        //shooting
        if(shoot == true)
        {
            bulletMaker.SetActive(true);
        }
        else
        {
            bulletMaker.SetActive(false);
        }


        if (patrol)
        {
            nav1.destination = goTo;
            if (Vector3.Distance(goTo, transform.position) < goalDistance)
            {
                ChooseLocation();
            }
            if((Vector3.Distance(player.position, transform.position) < playerRadius))
            {
                SetShoot();
            }
        }
        if (shoot)
        {
            nav1.destination = transform.position;
            if ((Vector3.Distance(player.position, transform.position) > playerRadius))
            {
                SetChase();
            }
        }
        if (chase)
        {
            nav1.destination = new Vector3(player.position.x, transform.position.y, player.position.z);
            if ((Vector3.Distance(player.position, transform.position) < playerRadius))
            {
                SetShoot();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand" && (leftHandVelocity.speed >= 4 || rightHandVelocity.speed >= 4))
        {
            tankDestroyed();
        }
        if (other.tag == "explosion")
        {
            tankDestroyed();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "hand" && VRHand.attached)
        {
            tankThrowScript.enabled = true;
            tankMovementScript.enabled = false;
        }
    }

    void ChooseLocation()
    {
        pickGoal = Random.Range(1, 10);
        switch (pickGoal)
        {
            case 1:
                goTo = goal1.position;
                break;
            case 2:
                goTo = goal2.position;
                break;
            case 3:
                goTo = goal3.position;
                break;
            case 4:
                goTo = goal4.position;
                break;
            case 5:
                goTo = goal5.position;
                break;
            case 6:
                goTo = goal6.position;
                break;
            case 7:
                goTo = goal7.position;
                break;
            case 8:
                goTo = goal8.position;
                break;
            case 9:
                goTo = goal9.position;
                break;
        }
    }
    void SetPatrol()
    {
        patrol = true;
        shoot = false;
        chase = false;
        ChooseLocation();
    }
    void SetShoot()
    {
        patrol = false;
        shoot = true;
        chase = false;
    }
    void SetChase()
    {
        patrol = false;
        shoot = false;
        chase = true;
    }

    void tankDestroyed()
    {
        spawnLimit.tankCounter++;
        Instantiate(explosionLarge, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
