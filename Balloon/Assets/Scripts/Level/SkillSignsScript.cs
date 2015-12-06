using UnityEngine;
using System.Collections;

public class SkillSignsScript : MonoBehaviour {



	public void activateSkill (int skillNum){
//		Debug.Log ("Activating skill: " + skillNum);
		switch (skillNum) {
		case 1:
			transform.Find("BirdSign").gameObject.SetActive(true);
			break;
		case 2:
			transform.Find("RabbitSign").gameObject.SetActive(true);
			break;
		case 3:
			transform.Find("FrogSign").gameObject.SetActive(true);
			break;
		case 4:
			transform.Find("MonkeySign").gameObject.SetActive(true);
			break;
		default:
			break;
		}
	}

	// Use this for initialization
	void Start () {
		transform.Find ("BirdSign").gameObject.SetActive (false);
		transform.Find ("RabbitSign").gameObject.SetActive (false);
		transform.Find ("FrogSign").gameObject.SetActive (false);
		transform.Find ("MonkeySign").gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
