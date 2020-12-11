using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    Transform player;

    public GameObject[] missleSpawn;
    public GameObject misslePrefab;

    public GameObject turret;
    private GameObject missle;

    public int playerRadius;

    public bool shoot;

    public float shotDelay;
    float shotDelayReset;

    public bool damageIndicatorOn = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("body").transform;

        shotDelayReset = shotDelay;
        shotDelay = Random.Range(shotDelay, shotDelay + 3.0f) * 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        float xVal = Mathf.Clamp(transform.eulerAngles.x, 0, 25);
        transform.eulerAngles = new Vector3(
            xVal,
            transform.eulerAngles.y,
            0
        );

        if (shoot)
        {
            if (Vector3.Distance(player.position, transform.position) > playerRadius)
            {
                shoot = !shoot;
            }

            if (shotDelay <= 0)
            {
                int spawnSelect = Random.Range(0, 8);

                missle = Instantiate(misslePrefab, missleSpawn[spawnSelect].transform.position, transform.rotation);
                missle.transform.SetParent(turret.transform);

                shotDelay = shotDelayReset;
                shotDelay = Random.Range(shotDelay, shotDelay + 3.0f) * 60f;
            }
            shotDelay--;
        }

        else
        {
            if (Vector3.Distance(player.position, transform.position) < playerRadius)
            {
                shoot = !shoot;
            }
        }

        if (damageIndicatorOn)
        {
            Register();
            damageIndicatorOn = false;
        }
    }

    public void Register()
    {
        if (!DamageIndicatorSystem.CheckIfObjectInSight(this.transform))
            DamageIndicatorSystem.CreateIndicator(this.transform);
    }
}
