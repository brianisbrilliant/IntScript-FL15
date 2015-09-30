using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class LostState : IStateBase {

		private StateManager manager;

		public LostState (StateManager managerRef) { 	// Constructor
			manager = managerRef;
			Debug.Log("LostState Constructed.");
			//Debug.Log("You require more minerals.");
		}

		public void StateUpdate() {
			if(Input.GetButtonUp("Jump")) {
				manager.SwitchState(new BeginState(manager));
				Application.LoadLevel("BeginningState");
			}
		}

		public void ShowIt() {

		}
	}
}