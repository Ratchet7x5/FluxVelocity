using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewards02 : MonoBehaviour
{
    // Achievement 03 Rewards
    public static int rewardCheck;
    public int rewardTrigger = 1;
    public int rewardCode = 0;
    public GameObject rewardNote;
    public bool rewardActive = false;

    void Update()
    {
        // When an achievement is earned the corresponding reward will become available via the function below
        rewardCode = PlayerPrefs.GetInt("Reward02");
        if (rewardCheck == rewardTrigger && rewardCode != 12345)
        {
            StartCoroutine(TriggerReward());
        }
    } 

    IEnumerator TriggerReward()
    {
        rewardActive = true;
        rewardCode = 12345;
        PlayerPrefs.SetInt("Reward02", rewardCode);
        rewardNote.SetActive(true);
        return null;
    }
}
