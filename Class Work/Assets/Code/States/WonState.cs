using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class WonState : IStateBase {

		private StateManager manager;

		public WonState (StateManager managerReference) { 	// Constructor
			manager = managerReference;
			Debug.Log("WonState Constructed.");
			//Debug.Log("Black Sheep Wall.");
		}

		public void StateUpdate() {
			if(Input.GetButtonUp("Jump"))
				manager.SwitchState(new BeginState(manager));
		}

		public void ShowIt() {

		}
	}
}