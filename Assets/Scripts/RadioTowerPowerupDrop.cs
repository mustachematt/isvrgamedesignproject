using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTowerPowerupDrop : MonoBehaviour
{
    public GameObject[] radioTowerPos;
    public Vector3[] originPos;
    Vector3 pickupPos;

    public bool[] hasSpawned;

    public GameObject pickup;

    public float setHeight;




    void Start()
    {
        originPos = new Vector3[radioTowerPos.Length];
        hasSpawned = new bool[radioTowerPos.Length];

        for (int i = 0; i < radioTowerPos.Length; ++i)
        {
            originPos[i] = new Vector3(radioTowerPos[i].transform.position.x,
                                        radioTowerPos[i].transform.position.y,
                                        radioTowerPos[i].transform.position.z);
            hasSpawned[i] = false;
        }
    }

    void Update()
    {
        for (int i = 0; i < radioTowerPos.Length; i++)
        {
            if (radioTowerPos[i] == null && hasSpawned[i] == false)
            {
                pickupPos = new Vector3(originPos[i].x, setHeight, originPos[i].z);
                Instantiate(pickup, pickupPos, Quaternion.identity);

                hasSpawned[i] = true;
            }
        }
    }
}
