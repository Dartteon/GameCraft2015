using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StageMakerScript : MonoBehaviour {
	public GameObject stageButtonPrefab;
	public GameObject pointerPrefab;
	private GameObject pointer;


	private List<GameObject> buttonList = new List<GameObject>();

	private float currentXPos, startYPos, startXPos;
	public int maxCol = 7;
	public float xDist = 1.5f;
	public float yDist = 3.0f;

	private int currentButtonIndex = 0;
	public int numStages;

	// Use this for initialization
	void Start () {
		currentXPos = this.transform.position.x;
		startXPos = currentXPos;
		startYPos = this.transform.position.y;

		for (int i = 0; i<numStages; i++) {
			float currentYPos = startYPos - (i/maxCol)*yDist;

			GameObject stageBtn = Instantiate(stageButtonPrefab, new Vector2(currentXPos, currentYPos), this.transform.rotation) as GameObject;
			StageButtonScript stageScript = stageBtn.GetComponent<StageButtonScript>();
			buttonList.Add(stageBtn);

			stageScript.setStageNumber(i+1);
			if (i/maxCol > 0){
				stageBtn.transform.Find("Body").GetComponentInChildren<SpriteRenderer>().sortingOrder = i;
				stageBtn.transform.Find("Body").GetComponentInChildren<Canvas>().sortingOrder = i+1;
			}

			currentXPos += xDist;
			if (i == maxCol-1){
				currentXPos = startXPos;
			}

		}
		pointer = Instantiate (pointerPrefab) as GameObject;
		setPointerPosition ();

	}

	void setPointerPosition(){
		Vector2 newPosition = buttonList [currentButtonIndex].transform.position;
		newPosition += new Vector2 (0, 1.0f);
		pointer.transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (currentButtonIndex > 0){
				currentButtonIndex--;
				setPointerPosition();
			} else {
				currentButtonIndex = numStages-1;
				setPointerPosition();
			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (currentButtonIndex < numStages-1){
				currentButtonIndex++;
				setPointerPosition();
			} else {
				currentButtonIndex = 0;
				setPointerPosition();
			}
			
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (currentButtonIndex - maxCol >= 0){
				currentButtonIndex -= maxCol;
				setPointerPosition();
			} else {
				currentButtonIndex += maxCol;
				setPointerPosition();
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (currentButtonIndex + maxCol <= numStages-1){
				currentButtonIndex += maxCol;
				setPointerPosition();
			} else {
				currentButtonIndex -= maxCol;
				setPointerPosition();
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			buttonList[currentButtonIndex].GetComponent<StageButtonScript>().activate();
		}
	}
}
