using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMorphingScript : MonoBehaviour {
	public int currentForm = 0;
	private bool[] hasPowerUp = {false, false, false, false, false};
	//0: snake, 1: bird, 2: rabbit, 3: frog
	public float morphCooldown;
	public float morphDuration = 0.3f;


	private GameObject morphingAnim;

	private GameObject snakeAspect, birdAspect, rabbitAspect, frogAspect, monkeyAspect;
	private GameObject currentAspect;

	private float lastMorphTime = -100f;

	private string currentStack = "";
//	private bool isMorphing = false;
//	private float morphCallTime;
//	public float morphDelay = 0.3f;

	private Text commandStackText;

	// Use this for initialization
	void Start () {
		configureAspects ();
	//	commandStackText = GameObject.Find ("Main Camera").transform.Find ("CommandStackCanvas").GetComponentInChildren<Text> ();
		//Debug.Log (commandStackText.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastMorphTime >= morphCooldown) {
			checkForMorphPress();
		}

		if (Time.time - lastMorphTime >= morphDuration) {
			morphingAnim.transform.Find ("Transform Process").GetComponent<SpriteRenderer> ().sortingOrder = -2;
			morphingAnim.transform.Find ("Transform Word").GetComponent<SpriteRenderer> ().sortingOrder = -2;
		}
	}

	void configureAspects(){
		snakeAspect = transform.Find ("SnakeAspect").gameObject;
		birdAspect = transform.Find ("BirdAspect").gameObject;
		rabbitAspect = transform.Find ("RabbitAspect").gameObject;
		frogAspect = transform.Find ("FrogAspect").gameObject;
		monkeyAspect = transform.Find ("MonkeyAspect").gameObject;
		morphingAnim = transform.Find ("MorphAnimation").gameObject;
		currentAspect = snakeAspect;
		currentAspect.SetActive (true);
	}

	void updateCommandStackText(){
	//	commandStackText.text = currentStack;
	}

	void checkForMorphPress(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			currentStack += 'q';
			updateCommandStackText();
		}
		else if (Input.GetKeyDown (KeyCode.W)) {
			currentStack += 'w';
			updateCommandStackText();
		} 
		else if (Input.GetKeyDown (KeyCode.E)) {
			currentStack += 'e';
			updateCommandStackText();
		} 
		else if (Input.GetKeyDown (KeyCode.R)) {
			currentStack += 'r';
			updateCommandStackText();
		} 
		else if (Input.GetKeyDown (KeyCode.A)) {
			currentStack += 'a';
			updateCommandStackText();
		} 
		
		if (currentStack.Length == 1){
			executeCommand(currentStack);
			currentStack = "";
			updateCommandStackText();
		//	triggerMorphSuccess();
		}


	}

	void displayMorphAnim(){
		morphingAnim.transform.Find ("Transform Process").GetComponent<SpriteRenderer> ().sortingOrder = 20;
		morphingAnim.transform.Find ("Transform Word").GetComponent<SpriteRenderer> ().sortingOrder = 20;
	}

	void executeCommand(string command){

		switch (currentStack) {
		case "q":
			changeToBirdAspect();
			break;
		case "w":
			changeToRabbitAspect();
			break;
		case "e":
			changeToFrogAspect();
			break;
		case "r":
			changeToSnakeAspect();
			break;
		case "a":
			changeToMonkeyAspect();
			break;
		default:
			showMorphError();
			break;
		}
	}

	public void powerUp(int i){
//		Debug.Log ("Powering Up: " + i);
		hasPowerUp [i] = true;
	}

	void changeToBirdAspect(){
		if (hasPowerUp[1] && currentAspect != birdAspect) {
			
			lastMorphTime = Time.time;
			displayMorphAnim();
			currentAspect.SetActive (false);
			currentAspect = birdAspect;
			birdAspect.SetActive (true);
		} else {
			showMorphError();
		}
	}

	void changeToRabbitAspect(){
		if (hasPowerUp[2] && currentAspect != rabbitAspect){
			lastMorphTime = Time.time;
			displayMorphAnim();
			currentAspect.SetActive(false);
			currentAspect = rabbitAspect;
			rabbitAspect.SetActive(true);
		} else {
			showMorphError();
		}
	}
	
	void changeToMonkeyAspect(){
		if (hasPowerUp[4] && currentAspect != monkeyAspect){
			lastMorphTime = Time.time;
			displayMorphAnim();
			currentAspect.SetActive(false);
			currentAspect = monkeyAspect;
			monkeyAspect.SetActive(true);
		} else {
			showMorphError();
		}
	}
	void changeToFrogAspect(){
		if (hasPowerUp[3] && currentAspect != frogAspect){
			lastMorphTime = Time.time;
			displayMorphAnim();
			currentAspect.SetActive(false);
			currentAspect = frogAspect;
			frogAspect.SetActive(true);
		}
	}
	
	void changeToSnakeAspect(){
		if (currentAspect != snakeAspect){
			lastMorphTime = Time.time;
			displayMorphAnim();
			currentAspect.SetActive(false);
			currentAspect = snakeAspect;
			snakeAspect.SetActive(true);
		}
	}
	
	void showMorphError(){
		Debug.Log ("Morph Error!");
	}

}
