using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{


    int counter = 0;
    public GameObject frontText;

    void FixedUpdate()
    {
        if (counter > 140)
        {
            Color col = gameObject.GetComponent<Text>().color;
            col.a -= 0.06f;
            gameObject.GetComponent<Text>().color = col;

            Color col2 = frontText.GetComponent<Text>().color;
            col2.a -= 0.03f;
            frontText.GetComponent<Text>().color = col2;
        }

        gameObject.GetComponent<RectTransform>().localScale *= 1.002f;

        counter++;
        if(counter >= 180)
        {
            Destroy(gameObject);
        }
    }
}
