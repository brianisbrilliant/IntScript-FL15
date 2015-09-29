using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class BeginState : IStateBase {

		StateManager manager;
		float futureTime = 0;
		int countDown = 0;
		float screenDuration = 8;

		public BeginState (StateManager managerReference) { 	// Constructor
			manager = managerReference;
			Debug.Log("BeginState Constructed.");
			futureTime = screenDuration + Time.realtimeSinceStartup;
			Time.timeScale = 0;
			//Debug.Log("You require more Vespene Gas.");
		}

		public void StateUpdate() {
			float rightNow = Time.realtimeSinceStartup;
			countDown = (int)futureTime - (int)rightNow;
			if(Input.GetButtonUp("Jump") || countDown <= 0) {
				Switch();
			}
		}

		public void ShowIt() {
			if(GUI.Button(new Rect(10,10,150,100), "Press to Play")) {
				manager.SwitchState(new PlayState(manager));
				Time.timeScale = 1;
			}
		}

		void Switch() {
			Time.timeScale = 1;
			manager.SwitchState(new PlayState(manager));
		}
	}
}