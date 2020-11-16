using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentIndicator : MonoBehaviour
{
    public GameObject counter;
    float needed;

    public GameObject neededText;

    void Start()
    {
        needed = counter.GetComponent<GlobalCounterScript>().winPercent;
        if(needed == 0.05)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-95,201,0);
        }
        else if(needed == 0.1)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-85, 201, 0);
        }
        else if (needed == 0.15)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-75, 201, 0);
        }
        else if (needed == 0.2)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-64, 201, 0);
        }
        else if (needed == 0.25)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-54, 201, 0);
        }
        else if (needed == 0.3)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-44, 201, 0);
        }
        else if (needed == 0.35)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-33, 201, 0);
        }
        else if (needed == 0.4)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-23, 201, 0);
        }
        else if (needed == 0.45)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-12, 201, 0);
        }
        else if (needed == 0.5)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2, 201, 0);
        }
        else if (needed == 0.55)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(8, 201, 0);
        }
        else if (needed == 0.6)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(18, 201, 0);
        }
        else if (needed == 0.65)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(29, 201, 0);
        }
        else if (needed == 0.7)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(39, 201, 0);
        }
        else if (needed == 0.75)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(49, 201, 0);
        }
        else if (needed == 0.8)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(60, 201, 0);
        }
        else if (needed == 0.85)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(70, 201, 0);
        }
        else if (needed == 0.9)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(80, 201, 0);
        }
        else if (needed == 0.95)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(91, 201, 0);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(101, 201, 0);
        }


        neededText.GetComponent<RectTransform>().anchoredPosition = 
            new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x,
            neededText.GetComponent<RectTransform>().anchoredPosition.y,
            0);

    }
    void Update()
    {
        bool won = counter.GetComponent<GlobalCounterScript>().gotNeededPercent;
        if (won == false)
        {
            //color blue
            gameObject.GetComponent<Image>().color = new Color32(54, 56, 204, 255);
        }
        else
        {
            //color purple
            gameObject.GetComponent<Image>().color = new Color32(248, 12, 238, 255);
        }
    }
}
