using UnityEngine;
using System.Collections;

public class BananaGunScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float firingCooldownTime = 1f;
    public float forceMultiplier = 10.0f;
    private bool isFacingRight;

    private float lastFiredTime;

    // Use this for initialization
    void Start()
    {
        lastFiredTime = Time.time;
        checkForErrors();
    }

    // Update is called once per frame
    void Update()
    {

        isFacingRight = transform.GetComponentInParent<MonkeyMovementScript>().getFacing();

       

        if (Time.time - lastFiredTime >= firingCooldownTime)
        {
			/*
            if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.UpArrow) && false)
            { 
				this.transform.parent.GetComponent<Animator>().Play("MonkeyThrow");
				Debug.Log(this.transform.parent.GetComponent<Animator>().ToString());
                GameObject bullet = Instantiate(bulletPrefab, new Vector3((isFacingRight)?this.transform.position.x+0.3f: this.transform.position.x-1.5f, this.transform.position.y, this.transform.position.z), this.transform.rotation) as GameObject;
                if (isFacingRight)
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f) * forceMultiplier, ForceMode2D.Impulse);
                } else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0f) * forceMultiplier, ForceMode2D.Impulse);
                }
                lastFiredTime = Time.time;
            }
*/
            if (Input.GetKey(KeyCode.Space))
			{
				this.transform.parent.GetComponent<Animator>().Play("MonkeyThrow");
//                Debug.Log("angled shot");
                GameObject bullet = Instantiate(bulletPrefab, new Vector3((isFacingRight) ? this.transform.position.x + 0.3f : this.transform.position.x - 1.5f, this.transform.position.y, this.transform.position.z), this.transform.rotation) as GameObject;
                if (isFacingRight)
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0.5f) * forceMultiplier, ForceMode2D.Impulse);
                } else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0.5f) * forceMultiplier, ForceMode2D.Impulse);
                }
                //Records the time it last fired
                lastFiredTime = Time.time;
            }
        }
    }

    void checkForErrors()
    {
        if (bulletPrefab == null)
        {
            Debug.Log("You haven't attached the bullet prefab to the gun!");
        }
    }
}
