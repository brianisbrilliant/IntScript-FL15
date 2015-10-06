using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class BeginState : IStateBase
	{
		private StateManager manager;
		
		public BeginState (StateManager managerRef)
		{
			manager = managerRef;
			Debug.Log ("In BeginState");
			if(Application.loadedLevelName != "Scene0")
				Application.LoadLevel("Scene0");
		}
		
		public void StateUpdate ()
		{
			if (Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new SetupState (manager));
			}
		}
		
		public void ShowIt ()
		{
			
		}
	}
}