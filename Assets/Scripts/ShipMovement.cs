using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    // Set CurrentSpeed to static, so the variable can be accessed from other class (InGameUIDisplay)
    [Tooltip("Ship initial Speed")][SerializeField] private float initialSpeed = 5f;
    [Tooltip("Ship current Speed")][SerializeField] public static float CurrentSpeed = 5f;
    [Tooltip("Ship Max Speed")][SerializeField] private float MaxSpeed = 10f;
    [Tooltip("Ship Braking Ratio")][SerializeField] private float brakingRatio = 0.8f;
    [Tooltip("Ship Boost Scaling")][SerializeField] private float BoostScale = 1.5f;
    [Tooltip("Maximum Velocity when Boosting")][SerializeField] private float MaxBoostedSpeed = 0f;
    [Tooltip("Speed gained per second")][SerializeField] private float Acceleration = 0.2f;

    [Tooltip("Ship turning speed")][SerializeField] private float turnSpeed = 100f;
    [Tooltip("Steer value")][SerializeField] private int steerValue = 2;
    
    public BoostGauge gaugeCurrent;

    // Start is called before the first frame update
    void Start()
    {
        // Reset the ship speed once start game
        CurrentSpeed = initialSpeed;

        gaugeCurrent.current = 0;
        MaxBoostedSpeed = BoostScale * MaxSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Read player's key script
        */
        //Read 
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
        
        //AUTO move forward
        //todo(tarun): speed increases each frame, needs a cap
        CurrentSpeed = (CurrentSpeed >= MaxSpeed) ? (CurrentSpeed = MaxSpeed) : (CurrentSpeed + Acceleration * Time.deltaTime);
        
        // Brake System
        // Press "Shift" to brake
        if (Input.GetKey(KeyCode.LeftShift)) {
            CurrentSpeed -= brakingRatio * Time.deltaTime;
        }

        // Moving forward
        transform.Translate(Vector3.down * CurrentSpeed * Time.deltaTime);

        // Boost speed
        if (Input.GetKey("space") && gaugeCurrent.current > 0) 
        {
            //have a scalar of MaxSpeed that determines the max speed during boost
            transform.Translate(Vector3.down * CurrentSpeed * Time.deltaTime);
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
