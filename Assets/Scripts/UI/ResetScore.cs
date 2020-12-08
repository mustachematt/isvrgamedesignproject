using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour
{
    public Text score;

    void Start()
    {
        score.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            PlayerPrefs.SetInt("highScore", 0);
            score.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        }


    }
}
