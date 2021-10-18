using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewards01 : MonoBehaviour
{
    // Achievement 01 Rewards
    public static int rewardCheck;
    public int rewardTrigger = 10;
    public int rewardCode = 0;
    public GameObject rewardNote;
    public bool rewardActive = false;

    void Update()
    {
        // When an achievement is earned the corresponding reward will become available via the function below
        rewardCode = PlayerPrefs.GetInt("Reward01");
        if (rewardCheck == rewardTrigger && rewardCode != 12345)
        {
            StartCoroutine(TriggerReward());
        }
    } 

    IEnumerator TriggerReward()
    {
        rewardActive = true;
        rewardCode = 12345;
        PlayerPrefs.SetInt("Reward01", rewardCode);
        rewardNote.SetActive(true);
        yield return new WaitForSeconds(1);
    }
}
