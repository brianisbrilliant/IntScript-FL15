using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class WonStateScene1 : IStateBase
	{
		private StateManager manager;
		
		public WonStateScene1 (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "Scene0")
				Application.LoadLevel("Scene0");
		}
				
		public void StateUpdate()
		{
			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				manager.SwitchState (new PlayStateScene2 (manager));
			}
		}
		
		public void ShowIt()
		{
			Debug.Log("In WonStateScene1");
		}
	}
}

