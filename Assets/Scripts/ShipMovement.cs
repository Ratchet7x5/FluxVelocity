using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [Tooltip("Ship current Speed")][SerializeField] private float speed = 10f;
    [Tooltip("Speed increasing per second")][SerializeField] private float speedGainPerSecond = 0.2f;

    [Tooltip("Ship turning speed")][SerializeField] private float turnSpeed = 100f;
    [Tooltip("Steer value")][SerializeField] private int steerValue = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Read player's key script,
        */
        if (Input.GetKey("a")) 
        {
            // Move Left
            transform.Rotate(0f, 0f, -steerValue * turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("d")) 
        {
            // Move Right
            transform.Rotate(0f, 0f, steerValue * turnSpeed * Time.deltaTime);
        }

        /*
        Ship moving forward script
        */
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (Input.GetKey("space")) 
        {
            // Initiate Boost
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        ShipFallOfTrack();
    }

    /*
    If player ship fall of the track (current Y position < -10),
    Reload the current scene

    Note : Need to destroy the MusicPlayer object when load MenuScene,
           If not, the code will Create a ANOTHER NEW MusicPlayer object.
    */
    private void ShipFallOfTrack()
    {
        // Get ship's current Y position
        float currentYPosition = transform.position.y;

        // If fall off track
        if (currentYPosition < -10)
        {
            // Find if the MusicPlayer existed
            GameObject music = GameObject.Find("MusicPlayer");

            // If the MusicPlayer existed, Destroy
            if(music)
                Destroy(music);

            // Load MainMenuScene
            SceneManager.LoadScene(0);
        }
    }
}
