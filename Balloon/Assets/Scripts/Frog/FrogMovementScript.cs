using UnityEngine;
using System.Collections;

public class FrogMovementScript : MonoBehaviour {
	public float jumpForce;
	public float jumpCooldown;
	public float hopCooldown;
	public float hopForce;

	Animator frogAnimator;

	private Vector2 zeroVector = new Vector2(0,0);
	private float lastHopTime = -100f;
	private float lastJumpTime = -100f;
	private Rigidbody2D playerRb2D;

	private bool canHop = true;
	private bool isFacingRight = false;

	void Start(){
		frogAnimator = transform.GetComponent<Animator> ();
	}

	void OnEnable(){
		playerRb2D = transform.parent.GetComponentInChildren<Rigidbody2D> ();
		playerRb2D.mass = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction = new Vector2 (0, 0);

		if (Input.GetKey (KeyCode.UpArrow)) {
		//	direction += new Vector2(0, 2f);
		}
		
		else if (Input.GetKey (KeyCode.DownArrow)) {
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			direction += new Vector2(-1f, 1f);
			isFacingRight = true;
		}
		
		else if (Input.GetKey (KeyCode.RightArrow)) {
			direction += new Vector2(1f, 1f);
			isFacingRight = false;
		}

		float currentTime = Time.time;
		bool isHopping = !direction.Equals (zeroVector);
		if (currentTime - lastHopTime >= hopCooldown && isHopping) {
			playerRb2D.AddForce (direction * hopForce, ForceMode2D.Impulse);
			lastHopTime = Time.time;
			canHop = false;
//			Debug.Log(transform.GetComponent<Animator>().ToString());
			transform.GetComponent<Animator>().Play("FrogHop");
//			frogAnimator.Play("FrogHop");
		} else {
		//	Debug.Log(canHop);
		}

		if (isFacingRight) {
			this.transform.parent.rotation = new Quaternion (0, 180, 0, 0);
		} else {
			
			this.transform.parent.rotation = new Quaternion(0,0,0,0);
		}
	}

	void OnCollisionEnter2D(){
		canHop = true;
		//Debug.Log ("Collided");
	}
}
