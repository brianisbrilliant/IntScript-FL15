using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class LostState : IStateBase {

		private StateManager manager;

		public LostState (StateManager managerReference) { 	// Constructor
			manager = managerReference;
			Debug.Log("LostState Constructed.");
			//Debug.Log("You require more minerals.");
		}

		public void StateUpdate() {
			if(Input.GetButtonUp("Jump"))
				manager.SwitchState(new BeginState(manager));
		}

		public void ShowIt() {

		}
	}
}