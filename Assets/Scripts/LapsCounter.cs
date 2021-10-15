using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsCounter : MonoBehaviour
{
    private int playerCount;
    private int[] enemiesAICount;

    private Dictionary<GameObject, int> dictionary;

    private void Start() {
        playerCount = 0;
        enemiesAICount = new int[3];
        dictionary = new Dictionary<GameObject, int>();

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
            if (playerCount >= 4) {
                /* Player WIN the race */
                // Debug.Log("Player WIN");
                GameObject.Find("RaceController").GetComponent<RaceControl>().GameWin();
            }
        }

        else if (other.CompareTag("Enemy")) {
            dictionary[other.gameObject]++;

            // Uncheck When need to debug
            // Debug.Log(other.gameObject.name + " lap(s) : "+dictionary[other.gameObject]);
            
            if (dictionary[other.gameObject] >= 4) {
                /* Player LOST the race */
                // Debug.Log("Player LOST");
                GameObject.Find("RaceController").GetComponent<RaceControl>().GameOver();
            }
        }
    }
}
