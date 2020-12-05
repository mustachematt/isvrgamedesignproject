using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject loadLevelManager;
    public bool playHit = false, quitHit = false;


    IEnumerator ChangeToScene(string scene)
    {
        yield return new WaitForSeconds(2);
        loadLevelManager.GetComponent<SteamVR_LoadLevel>().levelName = scene;
        loadLevelManager.SetActive(true);
    }

    
    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }


    private void Update()
    {
        if (playHit)
        {
            StartCoroutine(ChangeToScene("landscape"));
            playHit = false; // so there's only 1 invocation
        }

        if (quitHit)
        {
            StartCoroutine(QuitGame());
            quitHit = false; // so there's only 1 invocation
        }
    }
}
