using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
  public float setupSpinSpeed = 50.0f;
  public float speed = 16.0f;
  public float rotationSpeed = 0.60f;
  public float hoverPower = 3.5f;
  public Rigidbody projectile;

  public Color red = Color.red;
  public Color blue = Color.blue;
  public Color green = Color.green;
  public Color yellow = Color.yellow;
  public Color white = Color.white;

  private GameData gameDataRef;

  void Start () {
    gameDataRef = GameObject.Find("GameManager").GetComponent<GameData>();
  }

  void FixedUpdate() {
    float foreAndAft = Input.GetAxis ("Vertical") * speed;
    float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
    GetComponent<Rigidbody>().AddRelativeForce (-foreAndAft, 0, 0);
    GetComponent<Rigidbody>().AddTorque (0, rotation, 0);
  }

  void OnTriggerStay(Collider other) {
    GetComponent<Rigidbody>().AddForce(Vector3.up * hoverPower);
  }

  void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "GoodOrb") {
      gameDataRef.score += 1;
      Destroy(other.gameObject);
    }
  }

  void OnCollisionEnter(Collision collidedWith) {
    if(collidedWith.gameObject.tag == "BadOrb") {
      gameDataRef.playerLives -= 1;
      Destroy(collidedWith.gameObject);
    }
  }

  public void FireEnergyPulse() {
    Rigidbody clone;        // creating new variable of type Rigidbody.
    clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
    clone.transform.Translate(-1.5f, 0.05f, 0);         // make the projectile spawn in the right location (inside the gun barrel for instance.) BUT make sure it is outside of the player or it will immediately kill itself.
    clone.velocity = transform.TransformDirection(Vector3.left * 50);       // the direction the projectile goes.
  }

  public void PickedColor (Color playerColor) {
    GetComponent<Renderer>().material.color = playerColor;
  }
}
