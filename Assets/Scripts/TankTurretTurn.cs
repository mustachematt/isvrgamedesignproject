using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretTurn : MonoBehaviour
{
    public TankMovement tankMode;

    //float speed = 1.0f;
    Transform player;

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
        //Vector3 targetDirection = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.LookAt(player);
        }
    }
}
