using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyMenuButtons : MonoBehaviour
{
    public int myLevel;

    public Material red;
    public Material orange;

    int beatNormal;
    int beatHard;

    // Update is called once per frame
    void Update()
    {
        int currentLevel = PlayerPrefs.GetInt("difficulty", 2);
        beatNormal = PlayerPrefs.GetInt("beatNormal", 0);
        beatHard = PlayerPrefs.GetInt("beatHard", 0);


        if (myLevel == currentLevel)
        {
            //orange
            gameObject.GetComponent<MeshRenderer>().material = orange;
        }
        else
        {
            //red
            gameObject.GetComponent<MeshRenderer>().material = red;
        }


        if(myLevel == 0)
        {
            if(beatNormal == 0)
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text
                    = "???";
            }
            else if (beatNormal == 1)
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text
                    = "Endless";
            }
        }
        if(myLevel == 4)
        {
            if (beatNormal == 0)
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text
                    = "???";
            }
            else if (beatNormal == 1)
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text
                    = "Bonus";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            if(myLevel == 1 || myLevel == 2 || myLevel == 3)
                PlayerPrefs.SetInt("difficulty", myLevel);

            else
            {
                if(myLevel == 0)
                    if(beatNormal == 1)
                        PlayerPrefs.SetInt("difficulty", myLevel);
                if(myLevel == 4)
                    if(beatHard == 1)
                        PlayerPrefs.SetInt("difficulty", myLevel);
            }
        }
    }
}
