using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] private float distanceToTrack = 0f;
	public Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        //coll = GetComponent<Collider>();
    }
	
	float CheckTrack(Vector3 shipPos)
    {
        // The distance from the explosion position to the surface of the collider.
        Vector3 closestPoint = coll.ClosestPointOnBounds(shipPos);
        float distance = Vector3.Distance(closestPoint, shipPos);

		return distance;
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
		
		transform.Translate(Vector3.down * 2.5f * Time.deltaTime);
		
		distanceToTrack = CheckTrack(transform.position); 
		if(distanceToTrack < 0.05f){
			transform.Translate(Vector3.forward * 20f * Time.deltaTime);
		}
    }
}
