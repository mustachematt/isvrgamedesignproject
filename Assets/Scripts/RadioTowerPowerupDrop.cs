using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTowerPowerupDrop : MonoBehaviour
{
    BuildingCollision radioTower;

    Vector3 originPosition;
    Vector3 pickupPosition;

    public GameObject pickup;

    public float setHeight;

    bool hasSpawned;


    void Start()
    {
        hasSpawned = false;
        originPosition = transform.position;
        radioTower = GetComponent<BuildingCollision>();
    }

    void Update()
    {
        if ((radioTower.hitCount >= radioTower.destructionNum) && !hasSpawned)
        {
            originPosition = transform.position;
            pickupPosition = new Vector3(originPosition.x, setHeight, originPosition.z);
            Instantiate(pickup, pickupPosition, Quaternion.identity);

            hasSpawned = true;
        }
    }
}
