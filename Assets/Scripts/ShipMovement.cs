using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    // Set CurrentSpeed to static, so the variable can be accessed from other class (InGameUIDisplay)
    [Tooltip("Ship initial Speed")] [SerializeField] private float initialSpeed = 5f;
    [Tooltip("Ship current Speed")] [SerializeField] public static float CurrentSpeed = 5f;
    [Tooltip("Ship Max Speed")] [SerializeField] private float MaxSpeed = 10f;
    [Tooltip("Speed gained per second")] [SerializeField] private float Acceleration = 0.2f;
    [Tooltip("Ship Braking Ratio")] [SerializeField] private float brakingRatio = 0.8f;
    [Tooltip("Ship Boost Scaling")] [SerializeField] private float BoostScale = 1.5f;
    [Tooltip("Maximum Velocity when Boosting")] [SerializeField] private float MaxBoostedSpeed = 0f;

    [Tooltip("Ship turning speed")] [SerializeField] private float turnSpeed = 100f;
    [Tooltip("Steer value")] [SerializeField] private int steerValue = 2;
    //shunt
    [Tooltip("second before reset")] [SerializeField] private float rest = 0.5f;
    [Tooltip("count tap of keybored")] [SerializeField] private int tapcount = 0;
    // Sound Effects
    /* FRAGILE, DON'T TOUCH CODES THAT DEALT WITH SOUND EFFECT */
    [SerializeField] AudioClip runningEngineSound = null;
    [SerializeField] AudioClip brakingSound = null;    // If press "shift" (brakes)
    [SerializeField] AudioClip boostingSound = null;   // If press "space" (boost)

    // Audio control
    public static AudioSource audioSource;

    public BoostGauge gaugeCurrent;

    // Start is called before the first frame update
    void Start()
    {
        // Reset the ship speed once start game
        CurrentSpeed = initialSpeed;

        gaugeCurrent.current = 0;
        MaxBoostedSpeed = BoostScale * MaxSpeed;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = runningEngineSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Read player's heading direction key script
        */
        //Read 
        if (Input.GetKey("a"))
        {
            // Move Left
            transform.Rotate(0f, -steerValue * turnSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey("d"))
        {
            // Move Right
            transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        }

        //AUTO move forward
        //todo(tarun): speed increases each frame, needs a cap
        CurrentSpeed = (CurrentSpeed >= MaxSpeed) ? (CurrentSpeed = MaxSpeed) : (CurrentSpeed + Acceleration * Time.deltaTime);

        /*
        Brake System
        Press "Shift" to brake

        If braked, stop runningEngineSound sound effect
        */
        if (Input.GetKey(KeyCode.LeftShift) && CurrentSpeed > 0)
        {

            CurrentSpeed -= brakingRatio * Time.deltaTime;

            // If braking, stop runningEngineSound sound (if playing),
            // and play brakingSound
            if (audioSource.clip != brakingSound && audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.clip = brakingSound;
                audioSource.Play();
            }

            // If the current is brakingSound, but not playing,
            // replay
            if (audioSource.clip == brakingSound && !audioSource.isPlaying) {
                audioSource.Play();
            }
        }

        // If paused, stop sound effect
        if (PauseMenu.isGamePaused)
        {
            audioSource.Stop();
        }
        // If not braking, boosting & not pausing,
        // Play runningEngineSound sound effect
        else
        {
            // If not pressing "shift" (brake) and "space" (boost)
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("space"))
            {
                // If the current playing is not runningEngine,
                // stop the current, then play runningEngine
                if (audioSource.clip != runningEngineSound)
                {
                    audioSource.Stop();
                    audioSource.clip = runningEngineSound;
                    audioSource.Play();
                }
                // If the current is runningEngine, but not playing,
                // replay
                else if (audioSource.clip == runningEngineSound && !audioSource.isPlaying) {
                    audioSource.Play();
                }
            }

        }

        /* Moving forward control*/
        transform.Translate(Vector3.forward * CurrentSpeed * Time.deltaTime);

        /* Boost speed */
        if (Input.GetKey("space") && gaugeCurrent.current > 1)
        {
            //have a scalar of MaxSpeed that determines the max speed during boost
            transform.Translate(Vector3.forward * CurrentSpeed * Time.deltaTime);

            // If braking, stop runningEngineSound sound (if playing),
            // and play boostingSound
            if (audioSource.clip != boostingSound && audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.clip = boostingSound;
                audioSource.Play();
            }

            // If the current is brakingSound, but not playing,
            // replay
            if (audioSource.clip == boostingSound && !audioSource.isPlaying) {
                audioSource.Play();
            }
        }

        Shunt();
        ShipFallOfTrack();
    }

    private void Shunt()
    {   //shunting ship left
        if (Input.GetKeyDown("q"))
        {   //checking for double tap
            if (rest > 0 && tapcount == 1)
            {
                //shunting ship
                if (Input.GetKey("q"))
                {
                    transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime * 10);
                }
            }
            else
            {
                rest = 0.5f;
                tapcount += 1;
            }
        }
        if (Input.GetKeyDown("e"))
        {   //checking for double tap
            if (rest > 0 && tapcount == 1)
            {
                //shunting ship
                if (Input.GetKey("e"))
                {
                    transform.Translate(Vector3.right * CurrentSpeed * Time.deltaTime * 10);
                }
            }
            else
            {
                rest = 0.5f;
                tapcount += 1;
            }
        }
        //shunting ship phone tap
        /*
        if (Input.touchCount <= 0)
        {
            return;
        }
        for(touch in Input.touches) 
        {
            if (touch.tapCount == 2) 
            {
              transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime * 10);
            }    
        }   */
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
            if (music)
                Destroy(music);

            // Load MainMenuScene
            SceneManager.LoadScene(0);
        }
    }
}
