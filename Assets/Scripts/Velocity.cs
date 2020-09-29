using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float speed;
    public float delayUpdate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(velocity());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator velocity()
    {
        YieldInstruction waitTime = new WaitForSeconds(delayUpdate);
        Vector3 lastPos = transform.position;
        float lastTime = Time.time;

        while (enabled)
        {
            yield return waitTime;

            var deltaPos = (transform.position - lastPos).magnitude;
            var deltaTime = Time.time - lastTime;

            if (Mathf.Approximately(deltaPos, 0f))
                deltaPos = 0f;

            speed = deltaPos / deltaTime;

            lastPos = transform.position;
            lastTime = Time.time;
        }
    }
}
