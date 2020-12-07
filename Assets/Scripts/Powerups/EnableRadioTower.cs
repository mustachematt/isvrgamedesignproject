using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRadioTower : MonoBehaviour
{
    GlobalCounterScript globalCounter;

    BuildingCollision buildingDestrution;

    Collider towerCollider;

    public GameObject radioTowerHead;
    public GameObject radioTowerEffect;

    public float destroyRequirement;
    public bool hasBeenEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        globalCounter = GameObject.FindGameObjectWithTag("globalCounter").GetComponent<GlobalCounterScript>();
        towerCollider = GetComponent<Collider>();
        buildingDestrution = GetComponent<BuildingCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalCounter.percentDestroyed >= destroyRequirement && hasBeenEnabled == false)
        {
            buildingDestrution.enabled = true;
            towerCollider.enabled = true;
            radioTowerHead.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            radioTowerEffect.SetActive(true);
            hasBeenEnabled = true;
        }
    }
}
