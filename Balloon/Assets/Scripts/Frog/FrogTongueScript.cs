using UnityEngine;
using System.Collections;

public class FrogTongueScript : MonoBehaviour {

	FrogMovementScript movement;
	public GameObject tongueProjectilePrefab;

	public GameObject instantiatedTongueProjectile;
	private Rigidbody2D tongueRb2D;
	public float tongueForceMultiplier;

	public float tongueCooldown;
	private float lastTongueShotTime = -100f;

	private Vector2 zeroVector = new Vector2 (0, 0);
	private GameObject tongueGun;


	// Use this for initialization
	void Start () {
		movement = this.transform.GetComponent<FrogMovementScript>();
		tongueGun = this.transform.Find ("TongueGun").gameObject;
		createTongueObject ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			 if (Time.time - lastTongueShotTime >= tongueCooldown){
				instantiatedTongueProjectile.transform.position = tongueGun.transform.position;
				instantiatedTongueProjectile.SetActive(true);
				Vector2 direction = instantiatedTongueProjectile.transform.position - this.transform.position;
				tongueRb2D.velocity = zeroVector;
				tongueRb2D.AddForce(direction.normalized*tongueForceMultiplier, ForceMode2D.Impulse);
				lastTongueShotTime = Time.time;
			}
		}
		
		if (Input.GetKeyUp (KeyCode.Space)) {
			if (instantiatedTongueProjectile.activeInHierarchy){
				instantiatedTongueProjectile.SetActive(false);
				lastTongueShotTime = Time.time;
			}
		}

	}

	void createTongueObject(){
		instantiatedTongueProjectile = Instantiate (tongueProjectilePrefab) as GameObject;
		instantiatedTongueProjectile.GetComponent<SpringJoint2D> ().connectedBody = this.transform.parent.GetComponent<Rigidbody2D>();

//		instantiatedTongueProjectile = this.transform.Find ("TongueGun").transform.Find ("Tongue").gameObject;
		instantiatedTongueProjectile.SetActive (false);
		tongueRb2D = instantiatedTongueProjectile.GetComponent<Rigidbody2D> ();
		instantiatedTongueProjectile.GetComponent<TongueProjectileScript> ().setTongue (this.transform.gameObject);
	}

	void OnDisable(){
		if (instantiatedTongueProjectile != null) {
			instantiatedTongueProjectile.SetActive (false);
		}
	}
}
