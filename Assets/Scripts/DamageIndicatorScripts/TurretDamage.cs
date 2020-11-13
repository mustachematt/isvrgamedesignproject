using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamage : MonoBehaviour
{
    public int damage;

    public TurretBehavior turretParent = null;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.tag == "turret")
            turretParent = GetComponentInParent<TurretBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
