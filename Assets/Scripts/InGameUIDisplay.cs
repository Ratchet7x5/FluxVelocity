using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;

    private void Start() {
        textDisplay.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // If Boosting
        if (Input.GetKey("space")) {
            textDisplay.text = "Boosting";
        }
        // Else if braking
        else if (Input.GetKey(KeyCode.LeftShift)) {
            textDisplay.text = "Braking   " + Mathf.FloorToInt(ShipMovement.CurrentSpeed).ToString();
        }
        else {
            // Display ship's current speed
            textDisplay.text = Mathf.FloorToInt(ShipMovement.CurrentSpeed).ToString();
        }
        
    }
}
