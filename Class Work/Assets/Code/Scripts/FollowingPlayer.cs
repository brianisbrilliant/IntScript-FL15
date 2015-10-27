using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour
{
  public float cameraHeight = 17.0f;
  public float cameraDistance = 17.0f;

  private Transform playerPosition;

  void Start()
  {
    playerPosition = GameObject.Find("Player").transform;
  }

  void LateUpdate( )
  {
    transform.position = playerPosition.position +
      new Vector3(cameraDistance, cameraHeight,           -cameraDistance);
    transform.LookAt(playerPosition);
  }
}
