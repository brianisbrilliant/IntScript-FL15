using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
  public class LostStateScene2 : IStateBase
  {
    private StateManager manager;

    public LostStateScene2 (StateManager managerRef)
    {
      manager = managerRef;
      if(Application.loadedLevelName != "Scene0")
        Application.LoadLevel("Scene0");
    }

    public void StateUpdate()
    {
    }

    public void ShowIt()
    {
      GUI.DrawTexture(new
        Rect(0, 0, Screen.width, Screen.height),
        manager.gameDataRef.lostStateSplash,
        ScaleMode.StretchToFill);

      if (GUI.Button(new Rect(10, 10, 270, 30),
        "Click Here or Space key to repeat Level") ||
        Input.GetKeyUp (KeyCode.Space))
      {
        manager.SwitchState (new
          PlayStateScene2 (manager));
      }

      if (GUI.Button(new Rect(10, 50, 270, 30),
        "Click Here or Return key to Restart Game") ||
        Input.GetKeyUp (KeyCode.Return))
      {
        manager.Restart();
      }
    }
  }
}
