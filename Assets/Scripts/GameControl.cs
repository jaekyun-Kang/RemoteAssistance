using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	Dictionary<string, string> textList = new Dictionary<string, string> ();

	private bool detected = false;
	private bool flag = false;

	public GameObject text1;
	public GameObject confirmButton;
	public GameObject resetButton;

	public Animator animHDMI;
	public Animator animPower;

	public GameObject boxHDMI;
	public GameObject boxPower;

	private string text;
	private int sequence = 0;

	/*
	public enum TextManager
	{
		requireScan = "Please scan the Osprey", 
		scanComplete = "Scan Complete!",
		plugHDMI = "Please plug in the HDMI cable",
		completeHDMI = "HDMI connected!",
		plugPOWER = "Please plug in the Power cable",
		completePower = "Power connected!",
		setupDone = "Set up Completed!"
	};
	*/

	void Start(){
		sequence = 0;

		SetDictionary ();
		resetButton.SetActive (false);
		confirmButton.SetActive (false);
	}


	void SetDictionary(){
		textList.Add ("requireScan", "Please scan the Osprey");
		textList.Add ("scanComplete", "Scan Complete!");
		textList.Add ("plugHDMI", "Please plug in the HDMI cable");
		textList.Add ("completeHDMI", "HDMI connected!");
		textList.Add ("plugPOWER", "Please plug in the Power cable");
		textList.Add ("completePower", "Power connected!");
		textList.Add ("setupDone", "Set up Complete!");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			sequence++;
			if (sequence > 7) {
				sequence = 1;
			}
			if (sequence == 1) {
				Debug.Log (textList["requireScan"]);
				text = textList ["requireScan"];
			} else if (sequence == 2) {
				Debug.Log (textList["scanComplete"]);
				text = textList ["scanComplete"];
			} else if (sequence == 3) {
				Debug.Log (textList["plugHDMI"]);
				text = textList ["plugHDMI"];
			} else if (sequence == 4) {
				Debug.Log (textList["completeHDMI"]);
				text = textList ["completeHDMI"];
			} else if (sequence == 5) {
				Debug.Log (textList["plugPOWER"]);
				text = textList ["plugPOWER"];
			} else if (sequence == 6) {
				Debug.Log (textList["completePower"]);
				text = textList ["completePower"];
			} else if (sequence == 7) {
				Debug.Log (textList["setupDone"]);
				text = textList ["setupDone"];
			}
			text1.GetComponent<Text> ().text = text;

		}

	}

	public void OnConfirmButtonClicked(){

	}

	public void OnResetButtonClicked(){

	}

	IEnumerator DelayFunction(int sec){
		yield return new WaitForSeconds (sec);
	}
	/*
	// Use this for initialization
	void Start () {
		sequence = 0;
		resetButton.SetActive (false);
		confirmButton.SetActive (false);
		boxHDMI.SetActive (false);
		boxPower.SetActive (false);
		text = "Please scan the object";
		text1.GetComponent<Text> ().text = text;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {
			sequence = 1;
			flag = true;
		}
		detected = GameObject.Find ("GenerateImageAnchorCube").GetComponent<GenerateImageAnchor> ().isObjectDetected;
		if (detected && !flag) {
			sequence = 1;
			flag = true;
		}
		if (sequence > 0) {
			TextControl (sequence);
		}
		if (sequence == 0) {
			resetButton.SetActive (false);
		}
		Debug.Log (sequence);
	}


	public void OnConfirmButtonClicked(){
		if (sequence == 1) {
			sequence = 2;
			animHDMI.Play ("hdmi_animation");
		} else if (sequence == 2) {
			sequence = 3;
			animPower.Play ("PowerJack_animation");
		}
	}

	public void OnResetButtonClicked(){
			
		confirmButton.SetActive (false);
		text = "Please scan the object";
		text1.GetComponent<Text> ().text = text;
		sequence = 0;
		animHDMI.Play ("hdmiIdle");
		animPower.Play ("poweridle");
		boxHDMI.SetActive (false);
		boxPower.SetActive (false);
		flag = false;
	}

	public void TextControl(int num){
		switch (num) {
		case 1:	
			confirmButton.SetActive (true);
			text = "Please plug in the hdmi cable";
			text1.GetComponent<Text> ().text = text;
			boxHDMI.SetActive (true);
			break;
		case 2:
			text = "Please plugin the power cable";
			text1.GetComponent<Text> ().text = text;
			StartCoroutine ("TimerCount");

			break;

		case 3:
			text = "Set up done!";
			text1.GetComponent<Text> ().text = text;
			resetButton.SetActive (true);
			break;
		case 0:
			text = "Please scan the object";
			text1.GetComponent<Text> ().text = text;
			resetButton.SetActive (false);
			boxHDMI.SetActive (false);
			boxPower.SetActive (false);
			flag = false;
			break;
		}
	}

	IEnumerator TimerCount(){
		yield return new WaitForSeconds (2.0f);
		boxPower.SetActive (true);
	}

	*/

}
