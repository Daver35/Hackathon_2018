using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiLevel : MonoBehaviour {

	float timer = 0.0f;
	private Text timerLevel; 

	// Use this for initialization
	void Start () {
		timerLevel = GameObject.Find ("TimerText").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timerLevel.text = (int)timer + " seconds";
	}
}