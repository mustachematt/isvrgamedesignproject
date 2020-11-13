using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDifficulty : MonoBehaviour
{
    public int turretDifficulty;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        if (turretDifficulty >= difficulty || difficulty <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
