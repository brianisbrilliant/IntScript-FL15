using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;

public class StateManager : MonoBehaviour {

	private IStateBase activeState;
	static StateManager instanceRef;

	void Awake() {
		if(instanceRef == null) {
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			DestroyImmediate(gameObject);
	}

	void Start () {
		activeState = new BeginState(this);
		Debug.Log("This object is of the type '" + activeState + "'");
		//Debug.Log("food for thought");
	}
	
	void Update () {
		// this method is called every frame.
		if(activeState != null)
			activeState.StateUpdate();
	}

	public void SwitchState(IStateBase newState) {
		activeState = newState;
	}

	// this method is called every frame.
	// for displaying graphics, text, and buttons.
	void OnGUI() {
		if(activeState != null)
			activeState.ShowIt();
	}
}
