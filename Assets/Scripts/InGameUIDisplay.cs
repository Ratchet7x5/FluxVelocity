using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIDisplay : MonoBehaviour
{
    // Show player current speed
    [SerializeField] private TMP_Text textDisplay = null;

    // Show player labs
    [SerializeField] private TMP_Text lapCount;

    // Track Player labs
    private int playerLabCount;
    private string suffixText;

    private void Start() {
        playerLabCount = 0;
        textDisplay.text = "0";
        suffixText = "/"+LapsCounter.lapCounter;
        lapCount.text = "0"+suffixText;
    }

    // Update is called once per frame
    void Update()
    {
        // If Game is paused
        if (PauseMenu.isGamePaused) {
            textDisplay.text = "Pausing";
        }
        // If Boosting
        else if (Input.GetKey("w")) {
            textDisplay.text = "Boosting";
        }
        // Else if braking
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space)) {
            if (ShipMovement.CurrentSpeed < 0) {
                textDisplay.text = "Braking   " + 0;
            }
            else {
                textDisplay.text = "Braking   " + Mathf.FloorToInt(ShipMovement.CurrentSpeed).ToString();
            }
        }
        else {
            // Display ship's current speed
            textDisplay.text = Mathf.FloorToInt(ShipMovement.CurrentSpeed).ToString();
        }
        
        // Update player lab count text
        playerLabCount = LapsCounter.playerCount;
        if (playerLabCount - 1 >= 0) {
            lapCount.text = playerLabCount - 1 + suffixText;
        }
    }
}
