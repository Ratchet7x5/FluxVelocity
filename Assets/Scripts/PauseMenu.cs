using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeAndPauseButton()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game...");

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        Debug.Log("Pausing Game...");

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMainMenu()
    {
        GameObject music = GameObject.Find("MusicPlayer");
        if (music)
        {
            Destroy(music);
        }

        Debug.Log("Loading Main Menu...");
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Find if the MusicPlayer existed
        GameObject music = GameObject.Find("MusicPlayer");

        // If the MusicPlayer existed, Destroy
        if (music)
            Destroy(music);

        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
