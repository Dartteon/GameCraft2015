using UnityEngine;
using System.Collections;

public class EndLevelPortalScript : MonoBehaviour {
	private string nextLevelName;
	private float stageStartTime;

	private GameObject levelEndScreen;
	private LevelEndScreenScript levelEndScript;
	private GameObject camera;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		camera = GameObject.Find ("Main Camera");
		levelEndScreen = transform.Find ("LevelEndScreen").gameObject;
		levelEndScript = levelEndScreen.GetComponent<LevelEndScreenScript> ();
		stageStartTime = Time.time;

	//	Debug.Log(Application.loadedLevelName);
		string currStageName = Application.loadedLevelName;
		string currStageIndex = currStageName.Replace ("Level", "");

		int nextStageIndex = (System.Int32.Parse (currStageIndex)) + 1;
		nextLevelName = currStageName.Substring (0, 5) + (nextStageIndex);

	//	Debug.Log (nextLevelName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.name.Equals ("Player")) {
			triggerEndLevel();
		}

	}

	void triggerEndLevel(){
		float currentTime = Time.time;
		Time.timeScale = 0.1f;
		levelEndScript.triggerStageComplete (currentTime - stageStartTime, nextLevelName);
		levelEndScreen.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, 0);
		levelEndScreen.SetActive (true);

		levelEndScreen.transform.parent = camera.transform;
	}

}
