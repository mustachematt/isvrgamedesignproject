using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawn : MonoBehaviour
{

    public float despawnTime;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RemoveEffect());
    }

    IEnumerator RemoveEffect()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
