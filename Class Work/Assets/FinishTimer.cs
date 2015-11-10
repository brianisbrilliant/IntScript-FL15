using UnityEngine;
using System.Collections;

public class FinishTimer : MonoBehaviour {

	public float timer;
			int displayTimer;
			bool finished = false; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!finished)
			timer += Time.deltaTime;
	}

	void OnGUI() {
		if(GUI.Button(new Rect(10, 10, 80, 30), timer.ToString("0.00")))
			Application.LoadLevel("racing");			
	}

	void OnTriggerEnter() {
		finished = true;
	}
}
