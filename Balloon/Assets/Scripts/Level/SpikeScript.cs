using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name.Equals("Player")){
			GameObject.Find("Main Camera").transform.Find("RestartLevelButton(Clone)").GetComponentInChildren<RestartButtonScript>().restartLevel();
		}
	}
}
