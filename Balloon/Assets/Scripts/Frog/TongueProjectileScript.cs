using UnityEngine;
using System.Collections;

public class TongueProjectileScript : MonoBehaviour {

	private float activatedTime;
	public float lifespanTime;
	public bool isReturning = false;
	private GameObject playerTongue;
	private Rigidbody2D projectileRb2D;

	private GameObject tongueBody;

	Vector2 collidedPosition;
	private bool hasCollided = false;

	private Vector2 zeroVector = new Vector2(0,0);


	void OnEnable(){
		
		tongueBody = transform.Find ("TongueSquare").gameObject;
		tongueBody.transform.localScale = new Vector2(0, 0.2f);
		activatedTime = Time.time;
		hasCollided = false;
	}


	// Use this for initialization
	void Start () {
		projectileRb2D = this.GetComponent<Rigidbody2D> ();
		tongueBody = transform.Find ("TongueSquare").gameObject;
	}

	public void setTongue(GameObject tongue){
		playerTongue = tongue;
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasCollided && Time.time - activatedTime >= lifespanTime) {
			this.gameObject.SetActive (false);
//			projectileRb2D.velocity = zeroVector;
//			isReturning = true;
		} else if (hasCollided) {
			this.transform.position = collidedPosition;
		}

		
		
		Vector2 directionFromPlayer = this.transform.position - playerTongue.transform.position;
		float distanceFromPlayer = (this.transform.position - playerTongue.transform.position).magnitude;
		tongueBody.transform.localScale = new Vector2(1.4f * distanceFromPlayer, 0.2f);
		
		float angle = Mathf.Atan2 (directionFromPlayer.y, directionFromPlayer.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle - 90));
	}

	void FixedUpdate(){
	}

	void rotateToPlayer(){

	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Sticky") {
//			Debug.Log("Collided with " + col.ToString());
			hasCollided = true;
			collidedPosition = this.transform.position;	
		}
	}


}
