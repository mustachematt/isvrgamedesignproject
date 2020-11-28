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
        if(needed == 0.05f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-95,201,0);
        }
        else if(needed == 0.1f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-85, 201, 0);
        }
        else if (needed == 0.15f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-75, 201, 0);
        }
        else if (needed == 0.2f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-64, 201, 0);
        }
        else if (needed == 0.25f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-54, 201, 0);
        }
        else if (needed == 0.3f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-44, 201, 0);
        }
        else if (needed == 0.35f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-33, 201, 0);
        }
        else if (needed == 0.4f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-23, 201, 0);
        }
        else if (needed == 0.45f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-12, 201, 0);
        }
        else if (needed == 0.5f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2, 201, 0);
        }
        else if (needed == 0.55f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(8, 201, 0);
        }
        else if (needed == 0.6f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(18, 201, 0);
        }
        else if (needed == 0.65f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(29, 201, 0);
        }
        else if (needed == 0.7f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(39, 201, 0);
        }
        else if (needed == 0.75f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(49, 201, 0);
        }
        else if (needed == 0.8f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(60, 201, 0);
        }
        else if (needed == 0.85f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(70, 201, 0);
        }
        else if (needed == 0.9f)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(80, 201, 0);
        }
        else if (needed == 0.95f)
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
