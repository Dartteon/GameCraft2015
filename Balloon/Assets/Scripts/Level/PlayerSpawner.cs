using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerPrefab;


	// Use this for initialization
	void Start () {
		GameObject player = Instantiate (playerPrefab, this.transform.position, this.transform.rotation) as GameObject;
		player.name = "Player";

		GameObject.Find ("Main Camera").GetComponent<CameraTrackerScript> ().setPlayer (player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
