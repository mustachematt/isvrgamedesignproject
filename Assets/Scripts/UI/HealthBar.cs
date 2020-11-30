using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject counter;


    void Update()
    {
        gameObject.GetComponent<Slider>().value = counter.GetComponent<GlobalCounterScript>().health;
    }
}
