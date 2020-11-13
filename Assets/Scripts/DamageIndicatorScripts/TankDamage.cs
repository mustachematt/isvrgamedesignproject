using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDamage : MonoBehaviour
{
    public int damage;

    public BulletSpawner tankParent = null;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.tag == "tankBulletSpawner")
            tankParent = transform.parent.GetComponent<BulletSpawner>();
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
            tankParent.damageIndicatorOn = true;
        }
    }
}
