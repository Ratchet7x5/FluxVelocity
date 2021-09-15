using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] public TMP_Text TextBox;
    bool holda = true;
    bool holdd = false;
    bool holdspace = false;
    bool holdbreak = false;
    private void Start()
    {
        TextBox.text = "Press A to move left";
    }

    private void Update()
    {
        if (holda == true)
        {
            MoveLeft();
        }
        if (holdd == true)
        {
            MoveRight();
        }
        if (holdbreak == true)
        {
            airbreak();
        }
        if (holdspace == true)
        {
            Boost();
        }
    }
    private void MoveLeft()
    {
        if (Input.GetKey("a") || Input.GetKey("A"))
        {
            TextBox.text = " ";
            Debug.Log("Player pressed A...");
            holdd = true;
            holda = false;
        }
        
    }

    private void airbreak()
    {
        TextBox.text = "Press shift to break... ";
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TextBox.text = " ";
            Debug.Log("Player pressed shift...");
            holdspace = true;
            holdbreak = false;
        }

    }

    private void MoveRight()
    {
        TextBox.text = "Press D to move right";
        if (Input.GetKey("d") || Input.GetKey("D"))
        {
            TextBox.text = " ";
            Debug.Log("Player pressed D...");
            holdd = false;
            holdbreak = true;
        }
    }

    private void Boost()
    {
        TextBox.text = "Press space to boost";
        if (Input.GetKey("space"))
        {
            Debug.Log("Player pressed Space...");
            holdspace = false;
            TextBox.text = "YAY!! you know how to play. Go to main menu to exit Tutorial";
        }
    }
}
