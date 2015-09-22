using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class BeginState : IStateBase
	{
		public BeginState(string playerName, int age, string profession) {
			Debug.Log("Constructing BeginState.");
			int playerHealth;
			Debug.Log(playerName);
			Debug.Log(age);
			Debug.Log(profession);
		}

		public void StateUpdate() {

		}

		public void ShowIt() {

		}
	}
}