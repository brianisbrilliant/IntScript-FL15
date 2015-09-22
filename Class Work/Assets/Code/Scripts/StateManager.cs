using UnityEngine;
using Assets.Code.States;

public class StateManager : MonoBehaviour {

	private BeginState activeState;

	// Use this for initialization
	void Start () {
		activeState = new BeginState();
		Debug.Log("blah blah blah");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
