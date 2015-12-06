using UnityEngine;
using System.Collections;

public class BackGroundScript : MonoBehaviour {
	//private bool hasFoundPlayer = false;
	GameObject player;
	Vector2 playerStartPos;

	// Use this for initialization
	void Start () {
		//player = GameObject.Find ("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.Find ("Player").gameObject;
			playerStartPos = player.transform.position;
		} else {
			Vector2 playerCurrPos = player.transform.position;
			Vector2 displacement = playerStartPos - playerCurrPos;
			displacement *= 0.5f;
			this.transform.position = displacement;

		}
	}
}
