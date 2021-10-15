using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    // Load Map 01 scene Scene (index 1)
    public void LoadMap01()
    {
        SceneManager.LoadScene(1);
    }

    // Load Map 02 scene Scene (index 2)
    public void LoadMap02()
    {
        SceneManager.LoadScene(2);
    }

    // Load Tutorial Scene (index 3)
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(3);
    }

    // Quit Game method
    public void QuitGame() 
    {
        Application.Quit();
    }
}