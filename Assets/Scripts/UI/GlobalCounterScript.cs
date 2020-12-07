using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GlobalCounterScript : MonoBehaviour

{
    public int manualDifficultyTest_0to4_setTo5forOff = 5; // override playerprefs difficulty by setting to 0-4
                                                                // setting to anything else will use playerprefs

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

    public GameObject powerBar;

    public GameObject lostText;
    public GameObject lostTextBack;

    public GameObject powerCounter;

    public GameObject loadLevelManager;

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

    public float winPercent; //use decimal ---> ex: 0.8 = 80%
                      //to make percent bar indicator work, only have set to multiples of 5,   ex: 0.05, 0.10, 0.15, 0.20, 0.25, etc

    public float timerStartMinutes; //amount of time in minuites

    public int tankCounter;
    public int helicopterCounter;
    public int hotDogTruckCounter;

    public int currentDifficulty = 0; // don't edit, just public for other scripts to access, (instead use manualDifficultytest to test)

    //spawn limits
    int maxTankEasy = 10;
    int maxTankNormal = 14;
    int maxTankHard = 20;
    int maxHeliEasy = 2;
    int maxHeliNormal = 4;
    int maxHeliHard = 8;
    int maxHotDogNormal = 1;

    float powerUpPercent = 0;
    bool laserIsOn = false;
    int laserCount = 0;
    int maxLaser = 15;
    int LaserRemaining;

    void Awake()
    {
        
        //****************
        ////Difficulty////

        if (manualDifficultyTest_0to4_setTo5forOff == 0 ||
           manualDifficultyTest_0to4_setTo5forOff == 1 ||
           manualDifficultyTest_0to4_setTo5forOff == 2 ||
           manualDifficultyTest_0to4_setTo5forOff == 3 ||
           manualDifficultyTest_0to4_setTo5forOff == 4)
        {
            currentDifficulty = manualDifficultyTest_0to4_setTo5forOff;
        }
        else
        {
            currentDifficulty = PlayerPrefs.GetInt("difficulty", 2);
        }
            //Difficulty levels:
                // 0 - endless mode - mix between easy and normal, but no time limit
                // 1 - easy
                // 2 - normal
                // 3 - difficult
                // 4 - god mode (harder enemies and completion goal, but given all powerups)

        if(currentDifficulty == 0)
        {
            winPercent = 0.9f;
            timerStartMinutes = 1; // won't be used
            tankCounter = maxTankNormal;
            helicopterCounter = maxHeliNormal;
        }
        else if(currentDifficulty == 1)
        {
            winPercent = 0.6f;
            timerStartMinutes = 30;
            tankCounter = maxTankEasy;
            helicopterCounter = maxHeliEasy;
        }
        else if (currentDifficulty == 3)
        {
            winPercent = 0.8f;
            timerStartMinutes = 20;
            tankCounter = maxTankHard;
            helicopterCounter = maxHeliHard;
        }
        else if (currentDifficulty == 4)
        {
            winPercent = 0.8f;
            timerStartMinutes = 15;
            tankCounter = maxTankHard;
            helicopterCounter = maxHeliHard;
        }
        else   //normal mode
        {
            winPercent = 0.7f;
            timerStartMinutes = 20;
            tankCounter = maxTankNormal;
            helicopterCounter = maxHeliNormal;
        }

        hotDogTruckCounter = maxHotDogNormal; // only one option right now
        //////////////////
        //****************




        timer = timerStartMinutes * 60;
        health = maxHealth;
    }


    void Update()
    {
        //---power ups---
        maxLaser = 15;
        laserCount = powerCounter.GetComponent<LaserVision>().currentShotCount;
        laserIsOn = powerCounter.GetComponent<LaserVision>().enabled;

        LaserRemaining = maxLaser - laserCount;
        powerUpPercent = ((float)LaserRemaining / (float)maxLaser) * 100;

        /////adjust bar
        powerBar.SetActive(laserIsOn);
        powerBar.GetComponent<Slider>().value = powerUpPercent;
        //------

        if (currentPoints > PlayerPrefs.GetInt("highScore", 0))
            PlayerPrefs.SetInt("highScore", currentPoints);

        if (health > maxHealth)  //don't let heath go above starting health (for when regaining health)
            health = maxHealth;

        if (currentPercentPoints >= totalPercentPoints * winPercent) //if % destroyed
        {
            if (gotNeededPercent == false)
            {
                if (currentDifficulty == 0)
                {
                    currentPoints += 100000;
                }
                else if (currentDifficulty == 1)
                {
                    currentPoints += 200000;
                }
                else if (currentDifficulty == 3)
                {
                    currentPoints += 500000;
                }
                else if (currentDifficulty == 4)
                {
                    currentPoints += 500000;
                }
                else  //normal
                {
                    currentPoints += 400000;
                }
            }
            gotNeededPercent = true; //got needed percent
        }

        //timer
        if (won==false && lost == false)
        {
            if(currentDifficulty != 0)
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
        if (minleft >= 10)
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

        if(currentDifficulty == 0)  // adjust text if endless
        {
            timeString = "Time: --:--";
        }

        timerText.text = timeString;
        timerText2.text = timeString;


        if(currentPercentPoints >= totalPercentPoints && lost == false) // finish game if 100% destroyed
        {
            won = true;
        }

        if (won == true)
        {
            wonText1.SetActive(true);
            wonText1Back.SetActive(true);
            wonText2.SetActive(true);
            wonText2Back.SetActive(true);
            if(currentDifficulty == 3)
            {
                PlayerPrefs.SetInt("beatnormal", 1);
                PlayerPrefs.SetInt("beathard", 1);
            }
            else if(currentDifficulty == 2)
                PlayerPrefs.SetInt("beatnormal", 1);
            //stuff that happens when you win
            //------------------------
            //------------------------
            endGame();

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
            endGame();

        }
        else
        {
            lostText.SetActive(false);
            lostTextBack.SetActive(false);
        }
    }


    //currently damage is set to tank=1, heli=2, turret=2;
    public void TakeDamage(int damage)
    {
        int calculatedDamage;

        if(currentDifficulty == 0) //endless
        {
            calculatedDamage = damage;
        }
        else if(currentDifficulty == 1) //easy
        {
            calculatedDamage = damage;
        }
        else if(currentDifficulty == 3) //hard
        {
            calculatedDamage = damage + 2;
        }
        else if (currentDifficulty == 4) //god
        {
            calculatedDamage = damage + 2;
        }
        else                     // normal
        {
            calculatedDamage = damage + 1;
        }

        if(won == false && lost == false)
            health -= calculatedDamage;

        if(health <= 0)
        {
            lost = true;
        }
    }

    public void IncreaseHealth(int heal)
    {
        int calculated;

        if(currentDifficulty == 0 || currentDifficulty == 1)
        {
            calculated = heal + 6;
        }
        else if (currentDifficulty == 3 || currentDifficulty == 4)
        {
            calculated = heal;
        }
        else // normal
        {
            calculated = heal + 3;
        }
        
        health += calculated;
    }

    public void decreaseSpawnLimit() // to call when base destroyed
    {
        if(currentDifficulty == 1)
        {
            tankCounter -= 2;
            helicopterCounter -= 1;
        }
        else if(currentDifficulty == 3 || currentDifficulty == 4)
        {
            tankCounter -= 3;
            helicopterCounter -= 2;
        }
        else  // normal or endless
        {
            tankCounter -= 2;
            helicopterCounter -= 1;
        }
        
    }

    void endGame() //called after time over or health zero, 
                   // should stop movement, stop hands from destroying things, and start timer to return to menu 
    {
        StartCoroutine(returnToMenu());
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
    }

    IEnumerator returnToMenu()
    {
        yield return new WaitForSeconds(3);
        loadLevelManager.SetActive(true);
    }
}
