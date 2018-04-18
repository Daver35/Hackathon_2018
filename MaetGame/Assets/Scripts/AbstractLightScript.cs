using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractLightScript : MonoBehaviour {

	private GameObject lightPoint;

	// Use this for initialization
	void Start () {
		lightPoint = GetComponent<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Turn on the lights
	public void Light(){
		lightPoint.SetActive (true);
	}

	// Turn off the lights
	public void UnLight(){
		lightPoint.SetActive (false);
	}

}
