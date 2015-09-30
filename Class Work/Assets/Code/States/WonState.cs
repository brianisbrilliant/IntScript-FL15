using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class WonState : IStateBase {

		private StateManager manager;

		public WonState (StateManager managerRef) { 	// Constructor
			manager = managerRef;
			Debug.Log("WonState Constructed.");
			//Debug.Log("Black Sheep Wall.");
			Debug.Log("Hello World");
		}

		public void StateUpdate() {
			if(Input.GetButtonUp("Jump")) {
				Application.LoadLevel("BeginningState");
				manager.SwitchState(new BeginState(manager));
			}
		}

		public void ShowIt() {

		}
	}
}