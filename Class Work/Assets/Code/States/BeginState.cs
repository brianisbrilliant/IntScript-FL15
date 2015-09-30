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
			if(GUI.Button(new Rect((Screen.width / 2) - 75,(Screen.height / 2) - 50,150,100), "Press to Play")) {
				Switch();
				//manager.SwitchState(new PlayState(manager));
			}
		}

		void Switch() {
			Time.timeScale = 1;
			Application.LoadLevel("Scene1");		// name of scene save file
			manager.SwitchState(new PlayState(manager));
		}
	}
}