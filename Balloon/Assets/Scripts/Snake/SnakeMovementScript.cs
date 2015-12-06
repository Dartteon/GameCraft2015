using UnityEngine;
using System.Collections;

public class SnakeMovementScript : MonoBehaviour {

    private Vector2 zeroVector = new Vector2(0, 0);
    private Rigidbody2D playerRb2D;

    public float moveSpeed = 5f;

    private bool isFacingRight = true;

    // Use this for initialization
    void Start () {
        playerRb2D = transform.parent.GetComponent<Rigidbody2D>();
    }

	void OnEnable(){
		
		playerRb2D = transform.parent.GetComponentInChildren<Rigidbody2D> ();
		playerRb2D.mass = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = new Vector2(0, 0);

        if (Input.GetKey (KeyCode.LeftArrow)) {
			//direction += new Vector2 (-1f * moveSpeed, 0f);
			//playerRb2D.velocity = direction;
			Vector2 displacement = new Vector2(-1,0);
			displacement *= 0.05f;
			Vector2 newPosition = this.transform.position;
			newPosition += displacement;
			this.transform.parent.transform.position = newPosition;

			isFacingRight = false;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//direction += new Vector2 (1f * moveSpeed, 0f);
			//playerRb2D.velocity = direction;
			Vector2 displacement = new Vector2(1,0);
			displacement *= 0.05f;
			Vector2 newPosition = this.transform.position;
			newPosition += displacement;
			this.transform.parent.transform.position = newPosition;

			isFacingRight = true;
		} else {
			//playerRb2D.velocity = zeroVector;
		}

		if (isFacingRight) {
			this.transform.parent.rotation = new Quaternion (0, 0, 0, 0);
		} else {
			
			this.transform.parent.rotation = new Quaternion(0,180,0,0);
		}

    }
}
