using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* EnemyShip Control script */
public class EnemyShipController : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private List<GameObject> wayPoints;

    // Ship heading direction
    private Vector3 currentHeadingWayPoint;

    // Use to track current index in wayPoints List
    private int wayPointIndex;

    private float currentSpeed = 0;
    private int steerValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Set headingDirection to first index in a List
        currentHeadingWayPoint = wayPoints[0].transform.position;
        wayPointIndex = 0;
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Pass these values to methods below
        float forwardSpeed = currentSpeed;
        float turnAmount = 0;

        // Get a heading direction to move to
        Vector3 directionToMoveTo = (currentHeadingWayPoint - transform.position).normalized;

        // Get a direction angle
        float angleToDirection = Vector3.SignedAngle(transform.forward, directionToMoveTo, Vector3.up);

        // minimize the above value
        angleToDirection  *= -1;
        angleToDirection /= 45;

        // Move Right
        if (angleToDirection > 1) {
            turnAmount = steerValue;
        }
        // Move Left
        else if (angleToDirection < -1 ) {
            turnAmount = -steerValue;
        }

        // Accelerate
        currentSpeed = (currentSpeed == maxSpeed) ? (maxSpeed) : (currentSpeed + acceleration * Time.deltaTime);

        // For Debugging
        // Debug.Log(headingPosition);
        // Debug.Log(angleToDirection);

        ForwardMovement(forwardSpeed);
        LeftRightMovement(turnAmount);
    }

    // Moving Forward method
    private void ForwardMovement(float forwardInput) {
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime);
    }

    // Moving Left Right method
    private void LeftRightMovement(float steerInput) {
        transform.Rotate(0f, -steerInput * 100f * Time.deltaTime, 0f);
    }

    // Update new heading WayPoint
    private void UpdateNewWayPoint() {
        if (wayPointIndex == wayPoints.Count - 1) {
            wayPointIndex = -1;
        }
        currentHeadingWayPoint = wayPoints[++wayPointIndex].transform.position;
    }

    // When reached the current heading waypoint, update a new waypoint
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WayPoint")) {
            UpdateNewWayPoint();
        }
    }
}
