using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    /*
    Load the Tutorial Scene (index 1)
    */
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSettingMenu()
    {
        mainMenu.SetActive(false);
    }
}
