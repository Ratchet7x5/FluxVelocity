using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;

    [SerializeField] private float turnSpeed = 100f;
    private int steerValue = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")) 
        {
            transform.Rotate(0f, 0f, -steerValue * turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("d")) 
        {
            transform.Rotate(0f, 0f, steerValue * turnSpeed * Time.deltaTime);
        }

        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
