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
    Transform[] goals;

    NavMeshAgent nav1;

    int pickGoal;
    int goalDistance = 10;
    public int playerRadius = 20;  //was 30, changed to 20, and helicopter distance is 35 now.

    bool patrol = true;
    public bool shoot = false;
    public bool chase = false;

    Velocity leftHandVelocity;
    Velocity rightHandVelocity;

    public GameObject explosionLarge;

    GlobalCounterScript spawnLimit;
    TankThrow tankThrowScript;
    Throwable VRHand;

    int tankPointValue = 200;

    void Start()
    {
        goals = new Transform[] {
            GameObject.Find("tankGoal1").transform,
            GameObject.Find("tankGoal2").transform,
            GameObject.Find("tankGoal3").transform,
            GameObject.Find("tankGoal4").transform,
            GameObject.Find("tankGoal5").transform,
            GameObject.Find("tankGoal6").transform,
            GameObject.Find("tankGoal7").transform,
            GameObject.Find("tankGoal8").transform,
            GameObject.Find("tankGoal9").transform
        };
        player = GameObject.FindGameObjectWithTag("Player").transform;  //change to actual player obj when ready


        // For VR headset uncomment this 
        leftHandVelocity = GameObject.Find("LeftHandTrigger").GetComponent<Velocity>();
        rightHandVelocity = GameObject.Find("RightHandTrigger").GetComponent<Velocity>();

        // For testing without VR headset Uncomment this
        //leftHandVelocity = GameObject.Find("TempHandLeft").GetComponent<Velocity>();
        //rightHandVelocity = GameObject.Find("TempHandRight").GetComponent<Velocity>();

        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();

        tankThrowScript = GetComponent<TankThrow>();
        VRHand = GetComponent<Throwable>();
        nav1 = gameObject.GetComponent<NavMeshAgent>();

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
        if ((other.tag == "hand" && (leftHandVelocity.speed >= 4 || rightHandVelocity.speed >= 4)) || other.tag == "explosion")
        {
            tankDestroyed();
        }
    }

    public void PickUpTank()
    {
        nav1.enabled = false;
        bulletMaker.SetActive(false);
        tankThrowScript.enabled = true;
        gameObject.GetComponent<TankMovement>().enabled = false;
    }

    void ChooseLocation()
    {
        pickGoal = Random.Range(0, goals.Length);
        goTo = goals[pickGoal].position;
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
        GameObject.FindWithTag("globalCounter").GetComponent<GlobalCounterScript>().currentPoints += tankPointValue;
        if (gameObject.GetComponent<ThrowableTooltips>().attachedToHand)
            gameObject.GetComponent<ThrowableTooltips>().attachedToHand.DetachObject(gameObject);
        Destroy(gameObject);     
    }
}
