using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class BeginState : IStateBase
	{
		public BeginState() {
			Debug.Log("Constructing BeginState.");
		}

		public void StateUpdate() {

		}

		public void ShowIt() {

		}
	}
}