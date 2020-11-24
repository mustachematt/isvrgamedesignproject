using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserVision : MonoBehaviour
{
    public const int shotLimit = 15;
    public LayerMask mask;
    public GameObject line, explosion;
    public SteamVR_Action_Boolean shoot;
    public SteamVR_Input_Sources rightHand;

    private const float timeBetweenShots = 1;
    private float timer;
    private int shotsTaken;
    private LineRenderer lr;


    private void Start()
    {
        shotsTaken = 0;
        timer = timeBetweenShots;
        shoot.AddOnStateDownListener(Shooting, rightHand);
        lr = line.GetComponent<LineRenderer>();
    }


    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }


    private void Shooting(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (timer <= 0 && shotsTaken < 15)
            ShootLaser();
    }


    private void ShootLaser()
    {
        StartCoroutine(DisplayLaser());

        RaycastHit hit;
        if (Physics.Raycast(line.transform.position, line.transform.forward, out hit, 100, mask))
        {
            // instantiate the explosion and move it to where the laser hit
            GameObject instance = Instantiate(explosion, gameObject.transform);
            instance.transform.position = hit.transform.position;
        }
        ++shotsTaken;
    }


    private IEnumerator DisplayLaser()
    {
        lr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
    }
}
