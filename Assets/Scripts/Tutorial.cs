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
    bool pressBavialable = false;
    bool pressShiftavialable = false;
    bool pressSpaceavialable = false;

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

        if (pressBavialable == true)
        {
            MoveRight();
        }

        if (pressShiftavialable == true)
        {
            airbreak();
        }

        if (pressSpaceavialable == true)
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
            if (pressBavialable) {
                Invoke(nameof(AlreadyPressedD), delayTimes);
                pressBavialable = false;
            }
        }
    }

    private void airbreak()
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

    private void Boost()
    {
        // If press 'space', end tutorial
        if (Input.GetKey("space"))
        {
            TextBox.text = " ";
            if (pressSpaceavialable) {
                Invoke(nameof(AlreadyPressedSpace), delayTimes);
                pressSpaceavialable = false;
            }
        }
    }

    private void AlreadyPressedA() {
        pressBavialable = true;
        TextBox.text = "Press D to move right";
    }

    private void AlreadyPressedD() {
        pressShiftavialable = true;
        TextBox.text = "Press shift to break... ";
    }

    private void AlreadyPressedShift() {
        pressSpaceavialable = true;
        TextBox.text = "Press space to boost";
    }

    private void AlreadyPressedSpace() {
        TextBox.text = "YAY!! you know how to play. Go to main menu to exit Tutorial";
        GlobalAchievements.ach02Check = 1;        
    }

}
