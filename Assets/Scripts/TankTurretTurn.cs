using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretTurn : MonoBehaviour
{
    public TankMovement tankMode;

    Transform player;
    float strength = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (tankMode.shoot || tankMode.chase)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            float str = Mathf.Min(strength * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
        }
    }
}
