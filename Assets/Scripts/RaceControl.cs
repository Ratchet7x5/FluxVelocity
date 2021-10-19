using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceControl : MonoBehaviour
{
    // This variable value indicate how many labs need to finish Game
    // Used in LapsCounter.cs
    [SerializeField] private int lapCount = 2;

    public int GetLapCount() {
        return lapCount;
    }
    
    // If Player WIN
    public void GameWin() {
        Invoke(nameof(GameWinHelper), 0.7f);
    }

    private void GameWinHelper() {
        GameEnd("PLAYER WIN");
        
        if (SceneManager.GetActiveScene().buildIndex == 1 && GlobalAchievements.ach03Check != 1)
        {
            GlobalAchievements.ach03Check = 1;
            Rewards02.rewardCheck = 1;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && GlobalAchievements.ach04Check != 1)
        {
            GlobalAchievements.ach04Check = 1;
            Rewards03.rewardCheck = 1;
        }
    }

    // If Player LOST
    public void GameOver() {
        Invoke(nameof(GameOverHelper), 0.7f);
    }

    private void GameOverHelper() {
        GameEnd("PLAYER WIN");
    }

    private void GameEnd(string gameEndText) {
        // Freeze Game
        Time.timeScale = 0;
        // Turn Off Player Engine Sound
        GameObject.Find("Player").GetComponentInChildren<AudioSource>().volume = 0;
        // Find the In-Game Canvas Object
        GameObject canvas = GameObject.Find("Canvas").gameObject;
        // Get access to GameEndMenu (index 4)
        GameObject gameEndCanvas = canvas.transform.GetChild(4).gameObject;
        gameEndCanvas.SetActive(true);
        // Change GameEndText.text
        gameEndCanvas.transform.GetChild(2).GetComponent<Text>().text = gameEndText;
    }

    /*
    Load Next Map Scene

    E.G. If in Scene 1, load 2
    */
    public void LoadNextScene() {
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2) {
            SceneManager.LoadScene(1);
        }
        Time.timeScale = 1;
    }
}
