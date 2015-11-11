using UnityEngine;
using System.Collections;

public class PistolScript : MonoBehaviour {

	public Rigidbody bullet;
	public void Fire() {
    	Rigidbody clone;       // creating new variable of type Rigidbody.
    	clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
    	clone.transform.position = new Vector3(-1.5f, 0.05f, 10);         // make the projectile spawn in the right location (inside the gun barrel for instance.) BUT make sure it is outside of the player or it will immediately kill itself.
    	clone.velocity = transform.TransformDirection(Vector3.left * 50);       // the direction the projectile goes.
	}
}
