using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    /*
    Load the Tutorial Scene (index 1)
    */
    public void Load8BitScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    // Quit Game method
    public void QuitGame() 
    {
        Application.Quit();
    }
}