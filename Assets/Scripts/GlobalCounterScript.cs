using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCounterScript : MonoBehaviour

{ 
    public float winPercent; //change in editor - use decimal ---> ex: 0.8 = 80%
    public float timerStartMinutes; //change in editor - amount of time in minuites


    public Text percentText;
    public Text neededText;
    public Text healthText;
    public Text scoreText;
    public Text timerText;
    public GameObject wonText1;
    public GameObject wonText2;
    public GameObject lostText;


    public int totalPercentPoints = 0;  //the total sum of all existing building's points 
    public int currentPercentPoints = 0; //sum of points of buildings destroyed so far, used for percent calculation

    public int currentPoints = 0; // the total points player has accumulated, used to display point total.
                                  // includes building points plus points from other sources
                                  // like enemies killed, bonuses, etc


    public float percentDestroyed;
    public bool won = false;

    public int health = 100;

    float showNeeded;

    float timer;

    public bool lost = false;
    int minleft;
    int secleft;

    public int tankCounter;
    public int helicopterCounter;


    void Start()
    {
        timer = timerStartMinutes * 60;
    }


    void Update()
    {
        //timer
        if(won==false && lost == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if (currentPercentPoints >= totalPercentPoints * winPercent && lost == false) //if % destroyed
                {
                    won = true; //you win
                }
                else
                    lost = true;

                timer = 0;
            }
        }


        percentDestroyed = ((float)(currentPercentPoints) / (float)(totalPercentPoints))*100;

        percentText.text = percentDestroyed.ToString("F2") + "%";
        showNeeded = 100 * winPercent;
        neededText.text = showNeeded.ToString();
        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Score: " + currentPoints.ToString();
        minleft = (int)(timer / 60);
        secleft = (int)(timer % 60);

        if (secleft >= 10)
            timerText.text = "Time: " + minleft.ToString() + ":" + secleft.ToString();
        else
            timerText.text = "Time: " + minleft.ToString() + ":0" + secleft.ToString();


        if(won == true)
        {
            wonText1.SetActive(true);
            wonText2.SetActive(true);
            //stuff that happens when you win
            //------------------------
            //------------------------

        }
        else
        {
            wonText1.SetActive(false);
            wonText2.SetActive(false);
        }


        if(lost == true)
        {
            won = false; //make sure both not true
            lostText.SetActive(true);
            //stuff that happens if you lose
            //-------------------------
            //-------------------------

        }
        else
        {
            lostText.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
