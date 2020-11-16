using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollision : MonoBehaviour
{
    public Velocity velocityCheck1;
    public Velocity velocityCheck2;

    public GameObject rubbleEffect;
    public GameObject fireEffect;
    public GameObject smokeEffect;

    Vector3 originPosition;
    Vector3 fireLocation;

    public float shakeSpeed; 
    public float shakeIntensity;
    public float shakeRange;

    public float sinkDistance;
    float tempSinkDistance;
    public float sinkSpeed;

    int hitCount;
    public int destructionNum;


    public bool buildingHit = false;
    public bool isShaking = false;
    public bool fireOn = false;

    void Start()
    {
        tempSinkDistance = sinkDistance;
        originPosition = transform.position;
        fireLocation = new Vector3(transform.position.x, 20f, transform.position.z);
    }

     void FixedUpdate()
    {
        // Makes a building shake and sink into the ground
        if (isShaking)
        {
            if (tempSinkDistance > 0)
            {
                Vector3 sinkLocation = new Vector3(
                    originPosition.x + Random.Range(-shakeRange, shakeRange),
                    originPosition.y - (shakeIntensity * sinkSpeed),
                    originPosition.z + Random.Range(-shakeRange, shakeRange)
                );

                float step = shakeSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    sinkLocation,
                    step);

                tempSinkDistance -= sinkSpeed;

                if (tempSinkDistance <= 0)
                {
                    isShaking = false;
                    buildingHit = false;
                    hitCount++;
                    tempSinkDistance = sinkDistance;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "hand" && (velocityCheck1.speed >= 4 || velocityCheck2.speed >= 4)) || other.tag == "explosion")
        {
            if (gameObject.tag == "skyscraper" || gameObject.tag == "building" || gameObject.tag ==  "radioTower")
            {
                if(buildingHit == false)
                    SkyscraperHit(other.transform.position);
            }
            else if (gameObject.tag == "house")
            {
                HouseDestroy();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "vehicle" || other.gameObject.tag == "tank")
        {
            if (gameObject.tag == "skyscraper" || gameObject.tag == "building" || gameObject.tag == "radioTower")
            {
                if (buildingHit == false)
                    SkyscraperHit(other.transform.position);
            }
            else if (gameObject.tag == "house")
            {
                HouseDestroy();
            }
        }
    }

    //function called when skyscraper is hit with hand
    void SkyscraperHit(Vector3 handPosition)
    {
        int fireSpawnChance = Random.Range(0, 11);
        buildingHit = true;
        isShaking = true;

        originPosition = transform.position;

        Instantiate(rubbleEffect, handPosition, Quaternion.identity);

        if (fireSpawnChance == 10)
        {
            if (fireOn == false)
            {
                Instantiate(fireEffect, fireLocation, Quaternion.identity);
                Instantiate(smokeEffect, fireLocation, Quaternion.identity);
                fireOn = true;
            }
        }


        if (hitCount == destructionNum)
        {
            SkyscraperDestroy();
        }

    }

    //function called when skyscraper is destroyed
    void SkyscraperDestroy()
    {
        Destroy(gameObject);
    }

    //function for when house is hit with hand
    void HouseDestroy()
    {
        int fireSpawnChance = Random.Range(0, 5);

        Instantiate(rubbleEffect, transform.position, Quaternion.identity);

        if (fireSpawnChance == 4)
        {
            Instantiate(fireEffect, fireLocation, Quaternion.identity);
            Instantiate(smokeEffect, fireLocation, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
