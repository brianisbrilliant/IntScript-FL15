using UnityEngine;
using Assets.Code.Interfaces;
using System.Collections;

namespace Assets.Code.States
{
  public class SetupState : IStateBase
  {
    private StateManager manager;
    private GameObject player;
    private PlayerControl controller;

    public SetupState (StateManager managerRef)
    {
      manager = managerRef;
      if(Application.loadedLevelName != "Scene0")
        Application.LoadLevel("Scene0");

      player = GameObject.Find("Player");
      controller = player.GetComponent<PlayerControl>();
    }

    public void StateUpdate ()
    {
      if(!Input.GetButton("Jump"))
        controller.transform.Rotate(0,
        controller.setupSpinSpeed * Time.deltaTime, 0);
    }

    public void StateFixedUpdate()
    {
    }

    public void ShowIt ()
    {
      GUI.Box(new Rect(Screen.width - 110,10,100,25),
        string.Format("Lives left: " + manager.gameDataRef.playerLives));

      GUI.Box(new Rect(Screen.width -110,40,100,120), "Player Lives");

      if(GUI.Button(new Rect(Screen.width - 100,70,80,20), "5"))
        manager.gameDataRef.SetPlayerLives(5);

      if(GUI.Button(new Rect(Screen.width - 100,100,80,20), "10"))
        manager.gameDataRef.SetPlayerLives(10);

      if(GUI.Button(new Rect(Screen.width - 100,130,80,20), "Can't Lose"))
        manager.gameDataRef.SetPlayerLives(1000);

      GUI.Box(new Rect(10,10,100,180), "Player Color");

      if(GUI.Button(new Rect(20,40,80,20), "Red"))
        controller.PickedColor(controller.red);

      if(GUI.Button(new Rect(20,70,80,20), "Blue"))
        controller.PickedColor(controller.blue);

		if(GUI.Button(new Rect(20,100,80,20), "Green"))
        controller.PickedColor(controller.green);

     if(GUI.Button(new Rect(20,130,80,20), "Yellow"))
        controller.PickedColor(controller.yellow);

      if(GUI.Button(new Rect(20,160,80,20), "White"))
        controller.PickedColor(controller.white);

      GUI.Label(new Rect(Screen.width/2 -95,
        Screen.height - 100, 190, 30),
        "Hold Spacebar to pause rotation");

      if (GUI.Button(new Rect(Screen.width/2 -100, Screen.height - 50, 200, 40),
	  		"Click Here or Press 'P' to Play ") || Input.GetKeyUp(KeyCode.P)) {
        		manager.SwitchState (new PlayStateScene1_1(manager));
        		player.transform.position =	new Vector3(50, .5f, 40);
      }
    }
  }
}
