using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelEndScreenScript : MonoBehaviour {
	float stageEndTime;
	string nextLevel;


	public void triggerStageComplete(float endTime, string nextLevelName){
		stageEndTime = endTime;
		this.gameObject.SetActive (true);
		string time = stageEndTime.ToString().Substring(0,3);
		string endGameText = "Stage Completed! \n Timing: " + time + "s";
		this.transform.Find("EndLevelText").GetComponentInChildren<Text>().text = endGameText;
		nextLevel = (nextLevelName);
	}

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
		//	Debug.Log("Pressing Space");
			if (Time.time - stageEndTime >= 0.1f){
				Application.LoadLevel (nextLevel);
			}
		}
	}

	void OnEnable(){
		Rigidbody2D playerRb2D = GameObject.Find ("Player").GetComponent<Rigidbody2D> ();
		playerRb2D.gravityScale = 0;
		playerRb2D.velocity = new Vector2 (0, 0);

	}

	void OnMouseDown(){
		Time.timeScale = 1;
		Application.LoadLevel (nextLevel);
	}
}
