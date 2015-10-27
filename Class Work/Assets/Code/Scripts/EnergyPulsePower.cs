using UnityEngine;
using System.Collections;

public class EnergyPulsePower : MonoBehaviour
{
  public float pulseDuration = 2f;

  public Transform goodOrb;

  void Update()
  {
    pulseDuration -= Time.deltaTime;

    if(pulseDuration <= 0)
      Destroy(gameObject);
  }

  void OnCollisionEnter(Collision other)
  {
    if(other.gameObject.tag == "BadOrb") {
      Instantiate(goodOrb, other.transform.position,           other.transform.rotation);
      GameObject.Find("GameManager").
        GetComponent<GameData>().playerLives += 1;
      Destroy(other.gameObject);
      Destroy(gameObject);
    }
	else if (other.gameObject.name == "Terrain")
		Debug.Log("");
    else
      Destroy(gameObject);
  }
}
