using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingtime = 5f;

    private void Start()
    {
        currentTime = startingtime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //countDownText.text = currentTime.ToString();
    }
}
