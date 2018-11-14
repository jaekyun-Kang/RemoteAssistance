using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToBox : MonoBehaviour {

	public bool ready;
	public Transform target;

	private Transform orininPos;
	// Use this for initialization
	void Start () {
		ready = false;
		orininPos = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (ready == true) {
			Debug.Log ("please move");
			float step =.05f * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
}
