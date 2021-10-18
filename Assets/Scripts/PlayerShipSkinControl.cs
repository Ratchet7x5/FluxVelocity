using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipSkinControl : MonoBehaviour
{
    // Player Ship Skin
    public Material playerShipCurrentSkin;

    // Skin Options
    public Texture skin01;
    public Texture skin02;
    public Texture skin03;
    
    private void Awake() {

        // By default Player skin is set to skin01
        playerShipCurrentSkin.mainTexture = skin01;

        // This Object won't be destroyed when scene changed
        DontDestroyOnLoad(gameObject);
    }

    // Attached to Skin01Button
    public void Skin1Picked() {
        playerShipCurrentSkin.mainTexture = skin01;
    }

    // Attached to Skin02Button
    public void Skin2Picked() {
        playerShipCurrentSkin.mainTexture = skin02;
    }

    // Attached to Skin03Button
    public void Skin3Picked() {
        playerShipCurrentSkin.mainTexture = skin03;
    }
}
