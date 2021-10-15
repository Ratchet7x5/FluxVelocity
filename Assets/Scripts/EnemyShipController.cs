using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* EnemyShip Control script */
public class EnemyShipController : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5f;
    // Make currentSpeed SerializeField, just to see in Run time mode in Editor
    [SerializeField] private float currentSpeed = 0;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private GameObject getWayPointPath;

    // Store all Way points in this List
    private List<Transform> wayPoints = new List<Transform>();

    // Ship heading direction (mark waypoint)
    private Vector3 currentHeadingWayPoint;

    // Use to track current index in wayPoints List
    private int wayPointIndex;

    private int steerValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Get items (way points) from attached object's children
        Transform[] rawInfo = getWayPointPath.GetComponentsInChildren<Transform>();

        // Print out, For Debugging (for ease)
        // for (int i = 0; i < rawInfo.Length; i++) {
        //     Debug.Log(rawInfo[i]);
        // }

        // Add Way Points to inner List
        for (int i = 1; i < rawInfo.Length; i++) {
            wayPoints.Add(rawInfo[i]);
        }

        // Set headingDirection to first index in a List
        currentHeadingWayPoint = wayPoints[0].transform.position;
        wayPointIndex = 0;
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Pass these values to ForwardMovement() & LeftRightMovement()
        float forwardSpeed = currentSpeed;
        float turnAmount = 0;

        // Get a heading direction to move to
        Vector3 directionToMoveTo = (currentHeadingWayPoint - transform.position).normalized;

        // Get a direction angle to move to
        float angleToDirection = Vector3.SignedAngle(transform.forward, directionToMoveTo, Vector3.up);

        // Minimize the above variable value (for ease)
        angleToDirection  *= -1;
        angleToDirection /= 45;

        /*
        The <code>angleToDirection<code> return value between -2 to 2,
        If returned value is less than -1 turn, turn LEFT,
        If returned value is -1 < value < 1, goes forward,
        If returned value is more than 1 turn, turn RIGHT,
          */
        if (angleToDirection > 1) {
            turnAmount = steerValue;
        }
        else if (angleToDirection < -1 ) {
            turnAmount = -steerValue;
        }

        // Accelerate
        currentSpeed = (currentSpeed >= maxSpeed) ? (maxSpeed) : (currentSpeed + acceleration * Time.deltaTime);

        // For Debugging
        // Debug.Log(headingPosition);
        // Debug.Log(angleToDirection);

        LeftRightMoving(turnAmount);
        ForwardMoving(forwardSpeed);

        ShipFallOfTrack();
    }

    // Moving Forward method
    private void ForwardMoving(float forwardInput) {
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime);
    }

    // Moving Left-Right method
    private void LeftRightMoving(float steerInput) {
        transform.Rotate(0f, -steerInput * 100f * Time.deltaTime, 0f);
    }

    // Update (mark) new heading WayPoint
    private void UpdateNewHeadingWayPoint() {
        // If the heading way point is FINAL way point (last index)
        if (wayPointIndex == wayPoints.Count - 1) {
            wayPointIndex = -1;
        }
        currentHeadingWayPoint = wayPoints[++wayPointIndex].position;
    }

    // When reached the CURRENT marked heading waypoint, update a new waypoint
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WayPoint")) {
            UpdateNewHeadingWayPoint();
        }
    }

    // Similar with player ship, if fall off track ( Y position < -10)
    // Destroy gameobject
    private void ShipFallOfTrack()
    {
        // Get ship's current Y position
        float currentYPosition = transform.position.y;

        // If fall off track
        if (currentYPosition < -10)
        {
            Destroy(gameObject);
        }
    }
}
