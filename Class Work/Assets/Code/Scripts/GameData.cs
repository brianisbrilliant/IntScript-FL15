using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
  public Texture2D beginStateSplash;
  public Texture2D lostStateSplash;
  public Texture2D wonStateSplash;

  public List<GameObject> cameras;

  private int playerLivesSelected = 2;
  private int sceneBeginningScore;

  [HideInInspector]
  public int playerLives;
  [HideInInspector]
  public int score;

  void Start ()
  {
    playerLives = playerLivesSelected;
  }

  public void ResetPlayer()
  {
    playerLives = playerLivesSelected;
    score = sceneBeginningScore;
  }

  public void SetPlayerLives(int livesSelected)
  {
    playerLivesSelected = livesSelected;
    playerLives = livesSelected;
  }

  public void SetScore()
  {
    sceneBeginningScore = score;
  }
}
