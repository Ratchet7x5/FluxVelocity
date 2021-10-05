using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay = null;

    private void Start() {
        textDisplay.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // If Game is paused
        if (PauseMenu.isGamePaused) {
            textDisplay.text = "Pausing";
        }
        // If Boosting
        else if (Input.GetKey("space")) {
            textDisplay.text = "Boosting";
        }
        // Else if braking
        else if (Input.GetKey(KeyCode.LeftShift)) {
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
        
    }
}
