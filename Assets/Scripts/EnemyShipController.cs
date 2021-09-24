using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private List<GameObject> wayPoints;

    private Vector3 headingPosition;

    private int wayPointIndex;

    private float currentSpeed = 0;
    private int steerValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        headingPosition = wayPoints[0].transform.position;
        wayPointIndex = 0;
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardSpeed = currentSpeed;
        float turnAmount = 0;

        Vector3 directionToMovePosition = (headingPosition - transform.position).normalized;

        float angleToDirection = Vector3.SignedAngle(transform.forward, directionToMovePosition, Vector3.up);

        angleToDirection  *= -1;
        angleToDirection /= 45;

        if (angleToDirection > 1) {
            turnAmount = steerValue;
        }
        else if (angleToDirection < -1 ) {
            turnAmount = -steerValue;
        }

        // Accelerate
        currentSpeed = (currentSpeed == maxSpeed) ? (maxSpeed) : (currentSpeed + acceleration * Time.deltaTime);

        // Debug.Log(headingPosition);
        // Debug.Log(angleToDirection);

        ForwardMovement(forwardSpeed);
        LeftRightMovement(turnAmount);
    }

    private void ForwardMovement(float forwardInput) {
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime);
    }

    private void LeftRightMovement(float steerInput) {
        transform.Rotate(0f, -steerInput * 100f * Time.deltaTime, 0f);
    }

    private void UpdateNewWayPoint() {
        if (wayPointIndex == wayPoints.Count - 1) {
            wayPointIndex = -1;
        }
        headingPosition = wayPoints[++wayPointIndex].transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WayPoint")) {
            Debug.Log("Hitted!");
            UpdateNewWayPoint();
        }
    }
}
