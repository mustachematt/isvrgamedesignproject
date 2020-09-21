using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawn : MonoBehaviour
{

    int timeleft;

    // Start is called before the first frame update
    void Start()
    {
        timeleft = 30;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft--;
        if (timeleft <= 0)
            Destroy(gameObject);
    }
}
