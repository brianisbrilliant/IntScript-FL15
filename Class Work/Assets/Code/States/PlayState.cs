using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class PlayState : IStateBase {

		private StateManager manager;

		public PlayState (StateManager managerReference) { 	// Constructor
			manager = managerReference;
			Debug.Log("PlayState Constructed.");
			//Debug.Log("All your base are belong to us.");
		}

		public void StateUpdate() {
			if(Input.GetButtonUp("Jump"))
				manager.SwitchState(new WonState(manager));
			if(Input.GetKeyUp(KeyCode.Return))
				manager.SwitchState(new LostState(manager));
		}

		public void ShowIt() {

		}
	}
}