using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public bool playHit = false, quitHit = false;


    IEnumerator ChangeToScene(int scene)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
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
            StartCoroutine(ChangeToScene(1));
            playHit = false; // so there's only 1 invocation
        }

        if (quitHit)
        {
            StartCoroutine(QuitGame());
            quitHit = false; // so there's only 1 invocation
        }
    }
}
