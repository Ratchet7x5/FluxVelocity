using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsCounter : MonoBehaviour
{
    // This variable value indicate how many labs need to finish Game
    // Get from RaceController Gameobject RaceControl.cs
    public static int lapCounter;  // Using in InGameUIDisplay.cs (made static)

    // Track Player laps count
    public static int playerCount; // Using in InGameUIDisplay.cs (made static)

    // Track Enemy AI lap count
    private int[] enemiesAICount;

    // Decorator Pattern
    // Use Dictionary Collection to link Enemy AI with it's laps count variable
    private Dictionary<GameObject, int> dictionary;

    // Simple Particle effect when Player Win
    [SerializeField] private ParticleSystem playerWinParticle;

    // Play sound when player WIN
    private AudioSource playerWinSound;

    // Use this bool to indicate finish lap
    private bool gameFinished;

    private void Start()
    {
        gameFinished = false;
        lapCounter = GameObject.Find("RaceController").GetComponent<RaceControl>().GetLapCount();
        playerCount = 0;
        enemiesAICount = new int[3];
        dictionary = new Dictionary<GameObject, int>();

        // Assign each Enemy AI in scene to it's own Laps count
        for (int i = 0; i < 3; i++)
        {
            string name = "Enemy Ship 0" + i;
            GameObject enemy = GameObject.Find(name);
            enemiesAICount[i] = 0;
            dictionary.Add(enemy, enemiesAICount[i]);
        }

        playerWinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        // Only read when game is not finished
        if (!gameFinished)
        {
            if (other.CompareTag("Player"))
            {
                playerCount++;

                if (playerCount >= lapCounter + 1)
                {
                    /* Player WIN the race */
                    gameFinished = true;

                    // Play the assigned sound effect
                    playerWinSound.Play();

                    // Play the assigned particle effect
                    playerWinParticle.Play();

                    // Debug.Log("Player WIN");
                    /* Call Method from RaceController Objects script */
                    GameObject.Find("RaceController").GetComponent<RaceControl>().GameWin();
                }
            }

            else if (other.CompareTag("Enemy"))
            {
                dictionary[other.gameObject]++;

                // Uncheck When need to debug
                // Debug.Log(other.gameObject.name + " lap(s) : "+dictionary[other.gameObject]);

                if (dictionary[other.gameObject] >= lapCounter + 1)
                {
                    /* Player LOST the race */
                    gameFinished = true;

                    /* Call Method from RaceController Objects script */
                    GameObject.Find("RaceController").GetComponent<RaceControl>().GameOver();
                }
            }
        }
    }
}
