using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShipSkinControl : MonoBehaviour
{
    // Player Ship Skin
    public Material playerShipCurrentSkin;

    // Skin Options
    public Texture skin01;
    public Texture skin02;
    public Texture skin03;

    // Change inform text
    public TMP_Text text;
    
    private void Awake() {

        // By default Player skin is set to skin01
        playerShipCurrentSkin.mainTexture = skin01;

        // This Object won't be destroyed when scene changed
        DontDestroyOnLoad(gameObject);
    }

    // Attached to Skin01Button, Skin02Button & Skin03Button
    // Using returned index to choose Ship Skin
    public void PickSkin(int index) {
        if (index == 1)
            playerShipCurrentSkin.mainTexture = skin01;
        else if (index == 2)
            playerShipCurrentSkin.mainTexture = skin02;
        else
            playerShipCurrentSkin.mainTexture = skin03;

        ShowText();
    }

    // Show inform text when changed skin,
    // Then remove text in given time (second)
    private void ShowText() {
        text.text = "Skin Changed";
        Invoke(nameof(RemoveText), 1.5f);
    }

    // Remove text
    private void RemoveText() {
        text.text = "";
    }
}
