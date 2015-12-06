using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {
	Rigidbody2D playerRb2D;

	public float flapForceMultipler;
	public float lastFlapTime = -100f;
	public float flapCooldown;

	void OnEnable(){
		playerRb2D = transform.parent.GetComponent<Rigidbody2D> ();
		playerRb2D.mass = 0.5f;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && Time.time - lastFlapTime >= flapCooldown) {
			flap();
			lastFlapTime = Time.time;
		}
	}

	void flap(){
		playerRb2D.AddForce ((new Vector2 (0, 1)) * flapForceMultipler, ForceMode2D.Impulse);
	}
}
