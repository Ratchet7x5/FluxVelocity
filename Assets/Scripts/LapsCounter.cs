using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsCounter : MonoBehaviour
{
    // This variable value indicate how many labs need to finish Game
    // Get from RaceController Gameobject RaceControl.cs
    private int lapCounter;

    // Track Player laps count
    private int playerCount;

    // Track Enemy AI lap count
    private int[] enemiesAICount;

    // Decorator Pattern
    // Use Dictionary Collection to link Enemy AI with it's laps count variable
    private Dictionary<GameObject, int> dictionary;

    private void Start() {
        lapCounter = GameObject.Find("RaceController").GetComponent<RaceControl>().GetLapCount();
        playerCount = 0;
        enemiesAICount = new int[3];
        dictionary = new Dictionary<GameObject, int>();

        // Assign each Enemy AI in scene to it's own Laps count
        for (int i = 0; i < 3; i++) {
            string name = "Enemy Ship 0"+i;
            GameObject enemy = GameObject.Find(name);
            enemiesAICount[i] = 0;
            dictionary.Add(enemy,enemiesAICount[i]);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) {
            playerCount++;
            if (playerCount >= lapCounter + 1) {
                /* Player WIN the race */
                // Debug.Log("Player WIN");
                /* Call Method from RaceController Objects script */
                GameObject.Find("RaceController").GetComponent<RaceControl>().GameWin();
            }
        }

        else if (other.CompareTag("Enemy")) {
            dictionary[other.gameObject]++;

            // Uncheck When need to debug
            // Debug.Log(other.gameObject.name + " lap(s) : "+dictionary[other.gameObject]);
            
            if (dictionary[other.gameObject] >= lapCounter + 1) {
                /* Player LOST the race */
                // Debug.Log("Player LOST");
                /* Call Method from RaceController Objects script */
                GameObject.Find("RaceController").GetComponent<RaceControl>().GameOver();
            }
        }
    }
}
