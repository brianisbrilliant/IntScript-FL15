using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class PlayStateScene2 : IStateBase
	{
		private StateManager manager;

		public PlayStateScene2 (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "Scene2")
				Application.LoadLevel("Scene2");
		}
				
		public void StateUpdate()
		{
			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				manager.SwitchState (new WonStateScene2 (manager));
			}
			
			if (Input.GetKeyUp (KeyCode.Return)) 
			{
				manager.SwitchState (new LostStateScene2 (manager));
			}
		}
		
		public void ShowIt()
		{
			Debug.Log("In PlayStateScene2");
		}
	}
}

