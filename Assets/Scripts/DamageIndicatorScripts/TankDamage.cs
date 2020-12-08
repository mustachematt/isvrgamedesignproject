using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDamage : MonoBehaviour
{
    public int damage;

    public BulletSpawner tankParent = null;

    void Start()
    {
        if (transform.parent.tag == "tankBulletSpawner")
            tankParent = transform.parent.GetComponent<BulletSpawner>();

        transform.parent = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "body")
        {
            GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().TakeDamage(damage);
            tankParent.damageIndicatorOn = true;
        }
    }
}
