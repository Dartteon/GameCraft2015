using UnityEngine;
using System.Collections;

public class BananaScript : MonoBehaviour
{

    // This variable notes down the time that the object was made (instantiated)
    float instantiatedTime;
    
    // This variable denotes how long the projectile can "live" before it destroys itself
    // You can edit this variable in the Inspector window
    public float projectileLifeSpan = 3.0f;

    // Start() is called when the PLAY button is clicked!
    // This is coded to record down the time when this object was made
    void Start()
    {
        instantiatedTime = Time.time;

    }

    // Update is called once per frame
    // It continuously checks if this bullet has "expired", destroying it if it has
    void Update()
    {
        if (Time.time - instantiatedTime >= projectileLifeSpan)
        {
            Destroy(this.gameObject);
        }
    }

    // This function is called by Unity whenever the attached object hits another object
    // Make sure the attached object (bullet) has the CircleCollider2D component or this won't work!
    void OnCollisionEnter2D(Collision2D col)
    {
        string colliderTag = col.transform.tag;
        /*
        if (colliderTag != "Player" && colliderTag != "Floor" && col.gameObject.name != "MonkeyAspect")
        {
            Debug.Log(col.gameObject);
            Destroy(col.gameObject);
        }
        */
		
//		Debug.Log (colliderTag);
        if (col.gameObject.name == "Floor")
        {
            Destroy(this.gameObject, 0.2f);
        }

		if (colliderTag.Equals("Destroyable")){

			Destroy(col.gameObject.transform.parent.gameObject);
		}
    }
}
