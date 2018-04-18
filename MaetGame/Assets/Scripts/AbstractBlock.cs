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

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("collision detected " + collider.CompareTag ("Player"));
		if (collider.CompareTag ("Player")) {
			lightSys.Light ();
			PlayerController player = collider.gameObject.GetComponent<PlayerController>();
			player.StopMovement (); //velocity = new Vector2 (0, 0);
			player.SetReady(1f);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.CompareTag ("Player")) {
			lightSys.UnLight ();
		}
	}
}
