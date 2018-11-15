using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public Animator animHDMI;
	public Animator animPower;
	public GameObject boxHDMI;
	public GameObject boxPower;

	void Start(){
		boxHDMI.SetActive (false);
		boxPower.SetActive (false);
	}


	public void ScanObject(){
		
	
	}

	void Update(){
		
		if (GameObject.Find ("UIManager").GetComponent<UIControl> ().isPowerClicked) {
			boxPower.SetActive (true);
			animPower.Play ("PowerJack_animation");
		} else if (GameObject.Find ("UIManager").GetComponent<UIControl> ().isHDMIClicked) {
			boxHDMI.SetActive (true);
			animHDMI.Play ("hdmi_animation");
		} 
		if (GameObject.Find ("UIManager").GetComponent<UIControl> ().isResetClicked) {
			animHDMI.Play ("hdmiIdle");
			animPower.Play ("poweridle");
			boxHDMI.SetActive (false);
			boxPower.SetActive (false);
			GameObject.Find ("UIManager").GetComponent<UIControl> ().isPowerClicked = false;
			GameObject.Find ("UIManager").GetComponent<UIControl> ().isHDMIClicked = false;
			GameObject.Find ("UIManager").GetComponent<UIControl> ().isResetClicked = false;
		}

	}

	public void OnConfirmButtonClicked(){
		animHDMI.Play ("hdmi_animation");
		animPower.Play ("PowerJack_animation");
	}

	public void PlayHDMI(){
		animHDMI.Play ("hdmi_animation");
	}

	public void PlayPower(){
		animPower.Play ("PowerJack_animation");
	}

	public void OnResetButtonClicked(){
		animHDMI.Play ("hdmiIdle");
		animPower.Play ("poweridle");
	}
    
	public void SetActiveHDMI(bool flag){
		if (flag == false) {
			boxHDMI.SetActive (false);
		} else {
			boxHDMI.SetActive (true);
		}
	}

	public void SetActivePower(bool flag){
		if (flag == false) {
			boxPower.SetActive (false);
		} else {
			boxPower.SetActive (true);
		}
	}
}
