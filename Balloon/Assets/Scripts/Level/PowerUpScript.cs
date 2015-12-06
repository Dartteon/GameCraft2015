using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	public int powerUpType;
	SkillSignsScript skillSignScript;

	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log (col.ToString ());
		if (col.gameObject.name.Equals ("Player")) {
			skillSignScript = GameObject.Find("Main Camera").transform.GetComponentInChildren<SkillSignsScript>();
			Debug.Log(skillSignScript.ToString());
			skillSignScript.activateSkill(powerUpType);
			col.gameObject.GetComponent<PlayerMorphingScript>().powerUp(powerUpType);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log ("Triggered!" + col.ToString ());
		//Debug.Log (col.gameObject.name);
		if (col.transform.parent != null && col.transform.parent.gameObject.name.Equals ("Player")) {
			skillSignScript = GameObject.Find("Main Camera").transform.GetComponentInChildren<SkillSignsScript>();
//			Debug.Log(skillSignScript.ToString());
			skillSignScript.activateSkill(powerUpType);
			col.transform.parent.gameObject.GetComponent<PlayerMorphingScript>().powerUp(powerUpType);
			Destroy(this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
