using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageButtonScript : MonoBehaviour {
	public string stageName;

	public void setStageNumber(int i){
		this.stageName = "Level" + i;
		this.GetComponentInChildren<Text> ().text = "" + i;
	}


	void OnMouseDown(){
		activate ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate(){
		
		Time.timeScale = 1;
		Application.LoadLevel (stageName);
	}
}
