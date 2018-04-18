using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractBlock : MonoBehaviour {

	private AbstractLightScript lightSys;

	// Use this for initialization
	void Start () {
		lightSys = GetComponent<AbstractLightScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2d(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.Light ();
		}
	}

	void OnTriggerExit2d(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.UnLight ();
		}
	}
}
