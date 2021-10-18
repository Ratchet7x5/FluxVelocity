using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Showing text
    [SerializeField] public TMP_Text TextBox;

    // Time delay between each tutorial
    [Tooltip("Time delay between Tutorial")][SerializeField] private float delayTimes = 1.5f;

    bool pressAavialable = true;
    bool pressDavialable = false;
    bool pressShiftavialable = false;
    bool pressSpaceavialable = false;
    bool pressWavialable = false;

    private void Start()
    {
        TextBox.text = "Press A to move left";
    }

    private void Update()
    {
        if (pressAavialable == true)
        {
            MoveLeft();
        }

        if (pressDavialable == true)
        {
            MoveRight();
        }

        if (pressShiftavialable == true)
        {
            airbreakLeft();
        }
        if (pressSpaceavialable == true)
        {
            airbreakRight();
        }

        if (pressWavialable == true)
        {
            Boost();
        }
    }

    private void MoveLeft()
    {
        // If press 'a', show next tutorial
        if (Input.GetKey("a"))
        {
            TextBox.text = " ";
            if (pressAavialable) {
                Invoke(nameof(AlreadyPressedA), delayTimes);
                pressAavialable = false;
            }
        }
    }

    private void MoveRight()
    {
        // If press 'd', show next tutorial
        if (Input.GetKey("d"))
        {
            TextBox.text = " ";
            if (pressDavialable) {
                Invoke(nameof(AlreadyPressedD), delayTimes);
                pressDavialable = false;
            }
        }
    }

    private void airbreakLeft()
    {
        // If press 'shift', show next tutorial
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TextBox.text = " ";
            if (pressShiftavialable) {
                Invoke(nameof(AlreadyPressedShift), delayTimes);
                pressShiftavialable = false;
            }
        }
    }
    private void airbreakRight()
    {
        // If press 'space', show next tutorial
        if (Input.GetKey(KeyCode.space))
        {
            TextBox.text = " ";
            if (pressSpaceavialable) {
                Invoke(nameof(AlreadyPressedSpace), delayTimes);
                pressSpaceavialable = false;
            }
        }
    }

    private void Boost()
    {
        // If press 'w', end tutorial
        if (Input.GetKey("w"))
        {
            TextBox.text = " ";
            if (pressWavialable) {
                Invoke(nameof(AlreadyPressedW), delayTimes);
                pressWavialable = false;
            }
        }
    }

    private void AlreadyPressedA() {
        pressDavialable = true;
        TextBox.text = "Press D to move right";
    }

    private void AlreadyPressedD() {
        pressShiftavialable = true;
        TextBox.text = "Press shift to airbreak lect ";
    }

    private void AlreadyPressedShift() {
        pressSpaceavialable = true;
        TextBox.text = "Press Space to airbreak right";
    }
     private void AlreadyPressedSpace() {
        pressWavialable = true;
        TextBox.text = "Press w to Boost";
    }

    private void AlreadyPressedW() {
        TextBox.text = "YAY!! you know how to play. Go to main menu to exit Tutorial";
        GlobalAchievements.ach02Check = 1;        
    }

}
