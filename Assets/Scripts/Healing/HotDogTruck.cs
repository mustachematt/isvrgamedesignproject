using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public class HotDogTruck : MonoBehaviour
{

    Vector3 goTo;

    //Transform player;

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

    bool stopped = false;

    GlobalCounterScript spawnLimit;

    public int heal;

    // Start is called before the first frame update
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

        nav1 = GetComponent<NavMeshAgent>();

        spawnLimit = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();

        ChooseLocation();
    }

    void Update()
    {
        if (nav1.enabled) // is moving
        {
            nav1.destination = goTo;
            if (Vector3.Distance(goTo, transform.position) < goalDistance)
            {
                ChooseLocation();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
            nav1.enabled = false;

        if (other.tag == "head")
        {
            GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().IncreaseHealth(heal);
            spawnLimit.hotDogTruckCounter++;

            Hand holdingHand = gameObject.GetComponent<ThrowableTooltips>().attachedToHand;
            if (holdingHand == true)
                holdingHand.DetachObject(gameObject);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "body")
            nav1.enabled = false;
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

    public void PickUpTruck()
    {
        nav1.enabled = false;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
    }
}
