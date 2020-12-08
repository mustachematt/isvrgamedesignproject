using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatHardText : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("beatHard", 0) == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
