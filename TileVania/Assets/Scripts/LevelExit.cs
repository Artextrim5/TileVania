using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    LevelLouder Surtenlevel;

    private void Start()
    {
        Surtenlevel = FindObjectOfType<LevelLouder>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Surtenlevel.LoadNextLevel();
    }

}
