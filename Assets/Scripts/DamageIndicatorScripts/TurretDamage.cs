using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamage : MonoBehaviour
{
    public int damage;

    public TurretBehavior turretParent = null;

    void Start()
    {
        if (transform.parent.tag == "turret")
            turretParent = GetComponentInParent<TurretBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "body")
        {
            GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().TakeDamage(damage);
            turretParent.damageIndicatorOn = true;
        }
    }
}
