using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatNormalText : MonoBehaviour
{
    
    void Start()
    {
        if(PlayerPrefs.GetInt("beatNormal", 0) == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
