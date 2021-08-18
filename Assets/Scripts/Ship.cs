using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;

    [SerializeField] private float turnSpeed = 100f;
    private int steerValue = 2;

    // New Movement Variable
    float positionPitchFactor = -5f;
    float positionYawFactor = 5f;

    float controlPitchFactor = -20f;
    float controlRowFactor = -20f;

    float controlSpeeed = 10f;
    float xRange = 5f;
    float yRange = 3f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Read key
        if (Input.GetKey("a")) 
        {
            transform.Rotate(0f, 0f, -steerValue * turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("d")) 
        {
            transform.Rotate(0f, 0f, steerValue * turnSpeed * Time.deltaTime);
        }

        // Move Ship
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // ProcessTranslation();
        // ProcessRotation();
    }

    private void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToControlThrow + pitchDueToPosition;

        float yaw = transform.localPosition.x + positionYawFactor;

        float roll = xThrow * controlRowFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation() {
        // Test new Movement
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x * xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y * yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
