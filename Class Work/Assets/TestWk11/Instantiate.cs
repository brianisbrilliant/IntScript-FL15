using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {

	public GameObject projectile;

	void FixedUpdate () {
	}

	public void Shoot() { 
		Rigidbody clone;
    	clone = Instantiate(projectile, transform.position,transform.rotation) as Rigidbody;
    	clone.transform.Translate(0, .5f, 2.1f);
    	clone.velocity = transform.TransformDirection(Vector3.forward * 50);
	}
}
