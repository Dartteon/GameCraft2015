using UnityEngine;
using System.Collections;

public class RabbitMovementScript : MonoBehaviour
{
    private bool hopWhenTouchingGround = true;
    public float moveSpeed = 6f;
    public float hopForce;

	private GameObject jumpTarget;
    private Vector2 zeroVector = new Vector2(0, 0);
    private Rigidbody2D playerRb2D;

    private bool canHop;
    private bool isFacingRight = true;

    // Use this for initialization
    void Start()
    {
        playerRb2D = transform.parent.GetComponent<Rigidbody2D>();
		jumpTarget = transform.Find ("JumpTarget").gameObject;
    }

	void OnEnable(){
		
		playerRb2D = transform.parent.GetComponentInChildren<Rigidbody2D> ();
		playerRb2D.mass = 1f;
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, 0);

//		Debug.Log ("isg "+checkIfGrounded());

        if (Input.GetKey(KeyCode.UpArrow))
        {
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
        }

        if (Input.GetKey(KeyCode.LeftArrow) && checkIfGrounded())
        {
            direction += new Vector2(-1f * moveSpeed, 0f);
            playerRb2D.velocity = direction;
            isFacingRight = false;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && checkIfGrounded())
        {
            direction += new Vector2(1f * moveSpeed, 0f);
            playerRb2D.velocity = direction;
            isFacingRight = true;
        }

		if (isFacingRight) {
			this.transform.parent.rotation = new Quaternion (0, 0, 0, 0);
		} else {
			this.transform.parent.rotation = new Quaternion (0, 180, 0, 0);
		}

        if (Input.GetKey(KeyCode.Space))
        {
            if (checkIfGrounded())
            {
				/*
                if (isFacingRight)
                {
                    playerRb2D.AddForce(new Vector2(1f, 1f) * hopForce, ForceMode2D.Impulse);
                }
                else if (!isFacingRight)
                {
                    playerRb2D.AddForce(new Vector2(-1f, 1f) * hopForce, ForceMode2D.Impulse);
                }
				*/

				Vector2 jumpDirection = jumpTarget.transform.position - this.transform.position;
				jumpDirection.Normalize();
				playerRb2D.AddForce(jumpDirection*hopForce, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collide)
    {        
        
    }

	bool checkIfGrounded(){
		Vector2 currPos = new Vector2 (this.transform.position.x, this.transform.position.y - 0.7f);
		RaycastHit2D obj = Physics2D.Raycast (currPos, -Vector2.up, 0.0000001f);
	//	Debug.Log (obj.transform.ToString ());
		if (obj.transform != null && obj.transform.gameObject.tag.Equals("Floor")){
			return true;
		} else return false;

	}
}