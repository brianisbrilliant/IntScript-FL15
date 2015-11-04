using UnityEngine;
using System.Collections;

public class VehicleParent : MonoBehaviour {

	bool isParent = false;
	public GameObject player;	// assign the player here
	public Transform vehicle;	// assign the script to this object
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
			isParent = !isParent;
			SetParent();
	}

	void SetParent() {
		if(isParent) 
			player.transform.SetParent(vehicle);
		else
			player.transform.SetParent(null);
	}
}
