using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCounterScript : MonoBehaviour

{ 

    public float winPercent; //change in editor - use decimal ---> ex: 0.8 = 80%
           //to make percent bar indicator work, only have set to multiples of 5,   ex: 0.05, 0.10, 0.15, 0.20, 0.25, etc

    public float timerStartMinutes; //change in editor - amount of time in minuites

    int maxHealth = 100;


    public Text percentText;
    public Text percentText2;

    public Text neededText;
    public Text neededText2;

    public Text healthText;

    public Text scoreText;
    public Text scoreText2;

    public Text highScoreText;
    public Text highScoreText2;
    public Text highScoreTextBack;

    public Text timerText;
    public Text timerText2;

    public GameObject wonText1;
    public GameObject wonText1Back;
    public GameObject wonText2;
    public GameObject wonText2Back;

    public GameObject lostText;
    public GameObject lostTextBack;

    public int totalPercentPoints = 0;  //the total sum of all existing building's points 
    public int currentPercentPoints = 0; //sum of points of buildings destroyed so far, used for percent calculation

    public int currentPoints = 0; // the total points player has accumulated, used to display point total.
                                  // includes building points plus points from other sources
                                  // like enemies killed, bonuses, etc


    public float percentDestroyed;
    public bool won = false;

    public bool gotNeededPercent = false;

    public int health;

    float showNeeded;

    float timer;

    public bool lost = false;
    int minleft;
    int secleft;

    public int tankCounter;
    public int helicopterCounter;
    public int hotDogTruckCounter;


    void Start()
    {
        timer = timerStartMinutes * 60;
        health = maxHealth;
    }


    void Update()
    {

        if(currentPoints > PlayerPrefs.GetInt("highScore", 0))
            PlayerPrefs.SetInt("highScore", currentPoints);

        if (health > maxHealth)  //don't let heath go above starting health (for when regaining health)
            health = maxHealth;

        if (currentPercentPoints >= totalPercentPoints * winPercent) //if % destroyed
        {
            gotNeededPercent = true; //got needed percent
        }

        //timer
        if (won==false && lost == false)
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
        percentText2.text = percentDestroyed.ToString("F2") + "%";

        showNeeded = 100 * winPercent;

        neededText.text = showNeeded.ToString();
        neededText2.text = showNeeded.ToString();

        healthText.text = "Health: " + health.ToString();


        scoreText.text = "Score: " + currentPoints.ToString();
        scoreText2.text = "Score: " + currentPoints.ToString();

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0);
        highScoreText2.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0);
        highScoreTextBack.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0);

        minleft = (int)(timer / 60);
        secleft = (int)(timer % 60);


        string timeString;
        if (minleft > 10)
        {
            if (secleft >= 10)
                timeString = "Time: " + minleft.ToString() + ":" + secleft.ToString();
            else
                timeString = "Time: " + minleft.ToString() + ":0" + secleft.ToString();
        }
        else
        {
            if (secleft >= 10)
                timeString = "Time: 0" + minleft.ToString() + ":" + secleft.ToString();
            else
                timeString = "Time: 0" + minleft.ToString() + ":0" + secleft.ToString();
        }
        timerText.text = timeString;
        timerText2.text = timeString;

        if (won == true)
        {
            wonText1.SetActive(true);
            wonText1Back.SetActive(true);
            wonText2.SetActive(true);
            wonText2Back.SetActive(true);
            //stuff that happens when you win
            //------------------------
            //------------------------

        }
        else
        {
            wonText1.SetActive(false);
            wonText1Back.SetActive(false);
            wonText2.SetActive(false);
            wonText2Back.SetActive(false);
        }


        if(lost == true)
        {
            won = false; //make sure both not true
            lostText.SetActive(true);
            lostTextBack.SetActive(true);
            //stuff that happens if you lose
            //-------------------------
            //-------------------------

        }
        else
        {
            lostText.SetActive(false);
            lostTextBack.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void IncreaseHealth(int heal)
    {
        health += heal;
    }
}
