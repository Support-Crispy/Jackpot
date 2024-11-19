using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public static bool gameIsPaused;

    void Resume ()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused = false)
        {
            gameIsPaused = !gameIsPaused;
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused = true)
        {
            gameIsPaused = false;
            Resume();
        }
    }

    void Pause ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }
}
