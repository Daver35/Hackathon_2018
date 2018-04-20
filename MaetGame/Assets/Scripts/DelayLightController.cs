using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayLightController : MonoBehaviour {

	public GameObject lightPoint;
	public float delay;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	//Turn on the lights
	public void Light(){
		lightPoint.SetActive (true);
		Invoke ("UnLight",delay);
	}

	// Turn off the lights
	public void UnLight(){
		lightPoint.SetActive (false);
	}

}
