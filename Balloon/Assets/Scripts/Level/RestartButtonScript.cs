using UnityEngine;
using System.Collections;

public class RestartButtonScript : MonoBehaviour {

	void OnMouseDown(){
		restartLevel ();
		Time.timeScale = 1;
	}


	public void restartLevel(){
		string levelName = Application.loadedLevelName;
		Application.LoadLevel (levelName);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
