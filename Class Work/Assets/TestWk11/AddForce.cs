using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(Vector3.forward * 50);
		Destroy(gameObject, 2);
	}

	void OnCollisionEnter() {
		Destroy(gameObject);
	}
}
