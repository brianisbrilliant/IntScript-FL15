using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour
{
  private Transform playerPosition;

  void Start()
  {
    playerPosition = GameObject.Find("Player").transform;
  }

  void LateUpdate( )
  {
    transform.LookAt(playerPosition);
  }
}
