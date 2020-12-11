﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TankDamage : MonoBehaviour
{
    public int damage;
    public BulletSpawner tankParent = null;
    public SteamVR_Action_Vibration hapticAction;

    void Start()
    {
        if (transform.parent.tag == "tankBulletSpawner")
            tankParent = transform.parent.GetComponent<BulletSpawner>();

        transform.parent = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (tankParent == null)
            return;

        if (other.gameObject.tag == "body")
        {
            GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().TakeDamage(damage);
            tankParent.damageIndicatorOn = true;

            /*
             * Haptics...
             */

            Vector3 bodyHitDirection = transform.position - other.gameObject.transform.position;
            bodyHitDirection.Normalize();

            Transform camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

            float distance = bodyHitDirection.x - camera.forward.normalized.x;
            if (distance < -1)
            {
                float excess = Mathf.Abs(distance + 1);
                distance += excess;
            }
            if (distance > 1)
            {
                float excess = distance - 1;
                distance -= excess;
            }
            distance /= 2;

            float rhsAmp = 0.5f, lhsAmp = 0.5f;
            if (bodyHitDirection.z >= 0)
            {
                rhsAmp += distance;
                lhsAmp -= distance;
            }
            if (bodyHitDirection.z < 0)
            {
                rhsAmp -= distance;
                lhsAmp += distance;
            }

            hapticAction.Execute(0, 0.5f, 150, rhsAmp, SteamVR_Input_Sources.RightHand);
            hapticAction.Execute(0, 0.5f, 150, lhsAmp, SteamVR_Input_Sources.LeftHand);
        }
    }
}
