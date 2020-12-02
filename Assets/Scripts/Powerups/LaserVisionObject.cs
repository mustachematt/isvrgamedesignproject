using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Is a child class of Interactible to override its virtual functions
public class LaserVisionObject : Interactable
{
    public GameObject pickupEffect;
    private GameObject powerupManager;


    protected override void Start()
    {
        base.Start();
        powerupManager = GameObject.Find("PowerupManager");
    }


    protected override void Update()
    {
        base.Start();
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }


    protected override void OnHandHoverBegin(Hand hand)
    {
        base.OnHandHoverBegin(hand);
        powerupManager.GetComponent<LaserVision>().enabled = true;
        Destroy(gameObject);
    }


    protected override void OnDisable()
    {
        base.OnDisable();
    }
}