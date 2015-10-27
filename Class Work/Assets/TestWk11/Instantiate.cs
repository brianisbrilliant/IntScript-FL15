using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {

	public GameObject bullet;

	void FixedUpdate () {
		if(Input.GetButton("Fire1")) {
			Shoot();
		}
	}

	void Shoot() { 
		Rigidbody clone;
        clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        clone.velocity = transform.TransformDirection(Vector3.forward * 100);
	}
}
