using UnityEngine;
using Assets.Code.Interfaces;
using System.Collections;

namespace Assets.Code.States
{
	public class SetupState : IStateBase
	{
		private StateManager manager;
		
		public SetupState (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "Scene0")
				Application.LoadLevel("Scene0");
		}
		
		public void StateUpdate ()
		{
			if (Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new PlayStateScene1_1 (manager));
			}
		}
		
		public void ShowIt ()
		{
			Debug.Log ("In SetupState");
		}
	}
}

