using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class LostStateScene1 : IStateBase
	{
		private StateManager manager;

		public LostStateScene1 (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "Scene0")
				Application.LoadLevel("Scene0");
		}
		
		public void StateUpdate()
		{
			if (Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new PlayStateScene1_1 (manager));
			}

			if (Input.GetKeyUp (KeyCode.Return))
			{
				manager.Restart();
			}
		}

		public void ShowIt()
		{
			Debug.Log("In LostStateScene1");
		}
	}
}

