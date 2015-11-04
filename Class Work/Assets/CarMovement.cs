// this script goes on the car - it must have a
	// rigidbody component.

using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (transform.rotation.eulerAngles.z >= 90 || transform.rotation.eulerAngles.z <= -90)
        transform.eulerAngles = new Vector3(0, 0, 0);
	}
	
	public float speed = 16.0f, rotationSpeed = 0.60f;

	void FixedUpdate() {
    	float foreAndAft = Input.GetAxis ("Vertical") * speed;
    	float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
    	GetComponent<Rigidbody>().AddRelativeForce (0, 0, foreAndAft);
    	GetComponent<Rigidbody>().AddTorque (0, rotation, 0);
  	}



}

