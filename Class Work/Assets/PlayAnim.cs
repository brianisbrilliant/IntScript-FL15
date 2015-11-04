using UnityEngine;
using System.Collections;

public class PlayAnim : MonoBehaviour {

	public Animation anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Play();
		}
	}

	void Play() {
		anim.Play();
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log("Collision Detected");
		if(other.transform.tag == "Enemy")
			Destroy(other.gameObject);
	}
}
