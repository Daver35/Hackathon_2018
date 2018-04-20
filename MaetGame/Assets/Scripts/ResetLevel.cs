using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour {

	public Vector2 origin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset_Level(){
		GameObject.FindGameObjectWithTag ("Player").transform.position = origin;
	}
}
