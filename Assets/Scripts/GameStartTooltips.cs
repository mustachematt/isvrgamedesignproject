using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartTooltips : MonoBehaviour
{
    private DisplayTooltip displayTooltip;


    void Start()
    {
        displayTooltip = gameObject.GetComponent<DisplayTooltip>();
        StartCoroutine(DisplayStartingTooltips());
    }


    IEnumerator DisplayStartingTooltips()
    {
        yield return new WaitForSeconds(3);
        displayTooltip.HighlightMovementAxis(); // movement
        displayTooltip.HighlightSnapTurn(); // camera rotation

        yield return new WaitForSeconds(5);
        displayTooltip.UnhighlighMovementAxis();
        displayTooltip.UnhighlightSnapTurn();
    }
}
