using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterDamage : MonoBehaviour
{
    public int damage;

    public HelicopterMovement heliParent = null;

    void Start()
    {
        if (transform.parent.tag == "helicopter")
            heliParent = GetComponentInParent<HelicopterMovement>();

        transform.parent = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "body")
        {
            GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().TakeDamage(damage);
            heliParent.damageIndicatorOn = true;
        }
    }
}
