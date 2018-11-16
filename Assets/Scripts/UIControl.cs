using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.iOS;

public class UIControl : MonoBehaviour {

	private int step;

	public GameObject intro;
	public GameObject scanningGrid;
	public GameObject hdmi;
	public GameObject power;
	public GameObject done;

	public GameObject btn_Next;
	public GameObject btn_Reset;

	private bool detected;
	private bool flagForDetection;

	public bool isHDMIClicked;
	public bool isPowerClicked;
	public bool isResetClicked;

	void Start () {
		isHDMIClicked = false;
		isPowerClicked = false;
		isResetClicked = false;
		detected = false;
		flagForDetection = false;
		ShowIntro ();          //1
	}
	
	// Update is called once per frame
	void Update () {
		detected = GameObject.Find ("GenerateImageAnchorCube").GetComponent<GenerateImageAnchor> ().isObjectDetected;
		if (Input.GetKey (KeyCode.Space)) {
			detected = true;
		}
		if (detected && !flagForDetection) {
			ShowHDMI();   //3
			flagForDetection = true;
		}
	}

	public void OnNextButtonClicked(){
		if (hdmi.activeSelf) {
			isHDMIClicked = true;
			StartCoroutine (ShowPowerWithDelay (2.0f));
		}
		else if (power.activeSelf) {
			isPowerClicked = true;
			StartCoroutine (ShowCompleteWithDelay (2.0f));
		}
	}

	public void OnResetButtonClicked(){
		//Destroy (GameObject.Find ("parent"));
		ResetScene ();

		isHDMIClicked = false;
		isPowerClicked = false;
		flagForDetection = false;
		GameObject.Find ("GenerateImageAnchorCube").GetComponent<GenerateImageAnchor> ().isObjectDetected = false;

		GameObject.Find ("ARCameraManager").GetComponent<UnityARCameraManager> ().RestartAR ();

		ShowIntro ();
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//isResetClicked = true;

		//AllClear ();
		//ShowIntro ();
	}
	IEnumerator ShowPowerWithDelay(float sec){
		yield return new WaitForSeconds (sec);
		ShowPower ();
	}
	IEnumerator ShowCompleteWithDelay(float sec){
		yield return new WaitForSeconds (sec);
		ShowComplete ();
	}
	public void ShowIntro(){
		AllClear ();
		intro.SetActive (true);
		scanningGrid.SetActive (true);
		btn_Next.SetActive (false);
		btn_Reset.SetActive (false);
	}

	public void ShowHDMI(){
		AllClear();
		btn_Next.SetActive(true);
		hdmi.SetActive(true);
	}

	public void ShowPower(){
		AllClear ();
		power.SetActive (true);
		btn_Next.SetActive (true);
	}

	public void ShowComplete(){
		AllClear ();
		done.SetActive (true);
		btn_Reset.SetActive (true);
	}

	void AllClear(){
		intro.SetActive (false);
		scanningGrid.SetActive (false);
		hdmi.SetActive (false);
		power.SetActive (false);
		done.SetActive (false);
		btn_Next.SetActive (false);
		btn_Reset.SetActive (false);

	}

	public void ResetScene() {
		ARKitWorldTrackingSessionConfiguration sessionConfig = new ARKitWorldTrackingSessionConfiguration ( UnityARAlignment.UnityARAlignmentGravity, UnityARPlaneDetection.Horizontal);
		UnityARSessionNativeInterface.GetARSessionNativeInterface().RunWithConfigAndOptions(sessionConfig, UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors | UnityARSessionRunOption.ARSessionRunOptionResetTracking);
	}
}
