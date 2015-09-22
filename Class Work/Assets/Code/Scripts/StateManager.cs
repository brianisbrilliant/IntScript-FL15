using UnityEngine;
using Assets.Code.States;

public class StateManager : MonoBehaviour {

	private BeginState activeState;
	private BeginState secondState;

	// Use this for initialization
	void Start () {
		activeState = new BeginState("Brian", 26, "professor");
		secondState = new BeginState("Dumbledore", 150, "Headmaster");
		Debug.Log("blah blah blah");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
