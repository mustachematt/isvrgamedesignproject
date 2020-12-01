using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonSignal : MonoBehaviour
{
    public int buttonID;
    private MainMenuButtons mmb;


    private void Start()
    {
        mmb = GetComponentInParent<MainMenuButtons>();
    }


    private void OnDisable()
    {
        Debug.Log("OnDisable called");
        if (buttonID == 0) // if play button
            mmb.playHit = true;
        else if(buttonID == 1)// if quit button
            mmb.quitHit = true;
        else if (buttonID == 2) //easy
            PlayerPrefs.SetInt("difficulty", 1);
        else if (buttonID == 3) //normal
            PlayerPrefs.SetInt("difficulty", 2);
        else if (buttonID == 4) //hard
            PlayerPrefs.SetInt("difficulty", 3);
    }
}
