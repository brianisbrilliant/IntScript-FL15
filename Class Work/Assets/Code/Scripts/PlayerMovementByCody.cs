using UnityEngine;
using System.Collections;

public class PlayerMovmentByCody : MonoBehaviour {

	public AudioClip firstJump, secondJump;

	public float speed = 250, jumpPower = 400, jumpPower2 = 200, maxSpeed = 3, stompPower = 400, StompGravity, Gravity;
	public bool grounded, falling, canDoubleJump = true, canPassThroughPlatforms, dropping = false;
	public string playerNumber, AButton, BButton, XButton, YButton, Vertical, Horizontal;

	private Rigidbody2D rb2d;
	private Animator anim;
	private float lastY;
	private int jumpingUpLayer = 10, playerLayer = 8;
	private ScoreUI ScoreUI;		// check it! Hardcoded script finding.


//////////////////////////////////////////////////////////////////////
	// Use this for initialization
	void Start () {
		ScoreUI = GameObject.Find("CanvasUI").GetComponent<ScoreUI>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		if(!ScoreUI.gameOver)		// testing access to gameOver boolean
			Debug.Log("gameOver is false! Controls are active!");
		Debug.Log("Controls for player " + playerNumber + " are:");
		Debug.Log(BButton);
		Debug.Log(Vertical);
		Debug.Log(Horizontal);

	}
//////////////////////////////////////////////////////////////////////
	// Update is called once per frame
	void Update () {

		// if gameOver is false, let them move around. otherwise kill all control.
		if(!ScoreUI.gameOver) {
			//pass variables to animator
			anim.SetBool ("Grounded", grounded);
			anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis(Horizontal)));

			// Flip the sprite to face the direction of input
			if (Input.GetAxis(Horizontal) > 0.1f)
				transform.localScale = new Vector3 (.4f,.4f,.4f);

			if (Input.GetAxis(Horizontal) < -0.1f)
				transform.localScale = new Vector3 (-.4f,.4f,.4f);

			// Player jumping
			if (Input.GetButtonDown (BButton)) {
				if (grounded && (Input.GetAxis (Vertical) < 0)) {
					//drop coroutine
					StartCoroutine (Drop ());
				} else if (grounded) {
					//jump
					rb2d.AddForce (Vector2.up * jumpPower);
					//play 1st jump sound
					GetComponent<AudioSource> ().PlayOneShot (firstJump);
				} else if (!grounded && canDoubleJump && (Input.GetAxis (Vertical) >= 0)) {
					//jump with power2
					rb2d.AddForce (Vector2.up * jumpPower2);
					canDoubleJump = false;
					//play second sound
					//play 2nd jump sound
					GetComponent<AudioSource> ().PlayOneShot (secondJump);
				}
			}
			//stomp
			if(!grounded && (Input.GetButtonDown(YButton))){

					rb2d.AddForce(Vector2.down * stompPower);
				}

			if (grounded)
				canDoubleJump=true;


			//switching layers to move through objects
			//if youre jupmping up the put you on the jumping up layer
			//if falling, make falling bool true and put you on the falling layer
			if(!grounded) {
				if(gameObject.transform.position.y<(lastY+.05f)) {		// if y-pos is less than last frame
					if(canPassThroughPlatforms && !dropping) {				// i'm falling, make me collide with platforms
						canPassThroughPlatforms=false;
						falling = true;
						gameObject.layer=playerLayer;
					}
				} else {
					if(!canPassThroughPlatforms) {				// otherwise I'm still jumping, let me through platforms
						canPassThroughPlatforms=true;
						falling = false;
						gameObject.layer=jumpingUpLayer;
					}
				}
				lastY=gameObject.transform.position.y;			// what was our y=pos this frame?
			}
			else {
				falling = false;
			}

			// this is for keyboard movement.
			if(Input.GetKey(KeyCode.C) && Input.GetButtonDown(playerNumber)) {
				BButton = "Jump";
				Horizontal = "Horizontal";
				Vertical = "Vertical";
				YButton = "Fire1";
				Debug.Log("Player Number " + playerNumber + " is controlled by the keyboard.");
			}


			/*
			//I'm going to add gravity if not grounded, this should be a simple way to create a stomp
			if(!grounded && (Input.GetButtonDown(Stomp))){
				Physics.gravity = new Vector3(0, StompGravity, 0);
			}else{
				Physics.gravity = new Vector3(0, Gravity, 0);
			}
			*/
		}		// end of if (ScoreUI.gameOver)
	}
//////////////////////////////////////////////////////////////////////
	void FixedUpdate () {

		if(!ScoreUI.gameOver) {
			//get the player input direction
			float h = Input.GetAxis(Horizontal);

			//moving the player
			rb2d.AddForce((Vector2.right * speed) * h);

			//Limiting player speed
			if (rb2d.velocity.x > maxSpeed)
				rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);

			if (rb2d.velocity.x < -maxSpeed)
				rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
//////////////////////////////////////////////////////////////////////
	// Switching to fallinglayer - Let me drop down to the next platform
	IEnumerator Drop()
	{
			dropping=true;
			gameObject.layer = jumpingUpLayer;		// using the same non-collision layer as jumping up to the next platform
			rb2d.AddForce(Vector2.down * stompPower/4);
			yield return new WaitForSeconds(.1f);	// let us drop through and wait
			dropping=false;
			gameObject.layer=playerLayer;			//then let us go back to platform-colliding
	}
}