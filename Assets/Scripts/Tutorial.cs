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
    bool pressAShuntavialable = false;
    bool pressDShuntavialable = false;
    bool pressWavialable = false;
    public float presstimeL = 0.0f;
    public float presstimeR = 0.0f;
    public bool doublepressL = false;
    public bool doublepressR = false;
    [Tooltip("second before reset")] [SerializeField] private float rest = 0.5f;
    [Tooltip("count tap of keybored")] [SerializeField] private int tapcount = 0;

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
        if (pressAShuntavialable == true)
        {
            ShuntLeft();
        }
        if (pressDShuntavialable == true)
        {
            ShuntRight();
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
        if (Input.GetKey("space"))
        {
            TextBox.text = " ";
            if (pressSpaceavialable) {
                Invoke(nameof(AlreadyPressedSpace), delayTimes);
                pressSpaceavialable = false;
            }
        }
    }

     private void ShuntLeft()
    {
        // If double tap 'a', show next tutorial
        if (Input.GetKey("a")&& !doublepressL)
        {
            presstimeL = Time.time;
            if((Time.time - presstimeL) < 0.1f)
            {
                doublepressL = true;
            } 
        }
        if (Input.GetKey("a")&& doublepressL)
        {
            TextBox.text = " ";
            if (pressAShuntavialable) 
            {
                Invoke(nameof(AlreadyPressedShuntA), delayTimes);
                pressAShuntavialable = false;
            }
        }
            
    }
    private void ShuntRight()
    {
        // If double tap 'd', show next tutorial
        if(Input.GetKeyUp("d") && !doublepressR)
        {
            presstimeR = Time.time;
            if((Time.time - presstimeR) < 0.1f)
            {
                doublepressR = true;
            }
        }
        if (Input.GetKey("d") && doublepressR)
        {
            if (Input.GetKey("d"))
            {
                TextBox.text = " ";
                if (pressDShuntavialable) 
                {
                Invoke(nameof(AlreadyPressedShuntD), delayTimes);
                pressDShuntavialable = false;
                }
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
        pressAShuntavialable = true;
        TextBox.text = "double tap A to shunt left";
    }

    private void AlreadyPressedShuntA() {
        pressDShuntavialable = true;
        TextBox.text = "double tap D to shunt left";
    }

    private void AlreadyPressedShuntD() {
        pressWavialable = true;
        TextBox.text = "Press w to Boost";
    }


    private void AlreadyPressedW() {
        TextBox.text = "YAY!! you know how to play. Go to main menu to exit Tutorial";
        GlobalAchievements.ach02Check = 1;        
    }

}
