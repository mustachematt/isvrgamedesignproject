using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterDamage : MonoBehaviour
{
    public int damage;

    public HelicopterMovement heliParent = null;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.tag == "helicopter")
            heliParent = GetComponentInParent<HelicopterMovement>();
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
            heliParent.damageIndicatorOn = true;
        }
    }
}
