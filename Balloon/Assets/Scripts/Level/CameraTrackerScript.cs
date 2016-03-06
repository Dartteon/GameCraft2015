using UnityEngine;
using System.Collections;

public class CameraTrackerScript : MonoBehaviour {
	private GameObject player;
	public GameObject restartButtonPrefab;
	public GameObject transformationCuesPrefab;
	public GameObject homeButtonPrefab;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector2 (0, 0);
		player = GameObject.Find ("Player");
		GameObject rsButton = Instantiate (restartButtonPrefab, new Vector3(10f, 7f, 10f), this.transform.rotation) as GameObject;
		rsButton.gameObject.transform.parent = this.transform;
		GameObject signs = Instantiate (transformationCuesPrefab) as GameObject;
		signs.gameObject.transform.parent = this.transform;
		GameObject hmButton = Instantiate (homeButtonPrefab, new Vector3(11.5f, 7f, 10f), this.transform.rotation) as GameObject;
		hmButton.gameObject.transform.parent = this.transform;
	}

	public void setPlayer(GameObject thePlayer){
		player = thePlayer;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector2 playerLoc = player.transform.position;
			playerLoc += new Vector2 (0, 3.0f);
			Vector2 currLoc = this.transform.position;
			Vector2 newLoc = Vector2.Lerp (playerLoc, currLoc, Time.deltaTime);

			this.transform.position = new Vector3 (newLoc.x, newLoc.y, -10f);
		}
	}
}
