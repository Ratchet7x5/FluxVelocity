using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool bIsGamePaused = false;

    public GameObject PauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (bIsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resuming Game...");

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        bIsGamePaused = false;
    }

    public void Pause()
    {
        Debug.Log("Pausing Game...");

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        bIsGamePaused = true;
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu...");
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
