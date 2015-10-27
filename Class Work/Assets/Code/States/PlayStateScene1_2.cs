using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
  public class PlayStateScene1_2 : IStateBase
  {
    private StateManager manager;
    private GameObject player;
    private PlayerControl controller;

    public PlayStateScene1_2 (StateManager managerRef)
    {
      manager = managerRef;
      player = GameObject.Find("Player");
      controller = player.GetComponent<PlayerControl>();

      foreach(GameObject camera in                 manager.gameDataRef.cameras)
      {
        if(camera.name != "Following Camera")
          camera.SetActive(false);
        else
          camera.SetActive(true);
      }
    }

    public void StateUpdate()
    {
		if(manager.gameDataRef.playerLives <= 0)
      {
        manager.SwitchState(new LostStateScene1(manager));
        manager.gameDataRef.ResetPlayer();
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.position = new
        Vector3(50, .5f, 40);
      }

      if(manager.gameDataRef.score >= 2)
      {
        manager.SwitchState(new WonStateScene1(manager));
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.position = new
          Vector3(50, .5f, 40);
      }

      if(Input.GetKeyDown(KeyCode.LeftControl))
      {
        controller.FireEnergyPulse();
      }
    }

    public void ShowIt()
    {
      GUI.Box(new Rect(10,10,100,25),
        string.Format("Score: " + manager.gameDataRef.score));

      if(GUI.Button(new
        Rect(Screen.width/2 - 130, 10, 260, 30),
        string.Format("Click here or Press 1 for Level 1, State 1"))
        || Input.GetKeyUp(KeyCode.Alpha1))
      {
        manager.SwitchState(new PlayStateScene1_1(manager));
      }

      GUI.Box(new Rect(Screen.width - 110,10,100,25),
        string.Format("Lives left: "+ manager.gameDataRef.playerLives));
    }
  }
}
