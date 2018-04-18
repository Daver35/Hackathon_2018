using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBlockController : MonoBehaviour {

	private AbstractLightScript lightSys;
	public int direction;

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
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			int dir = player.GetDirection();
			if(direction == 0 && (dir == 1 || dir == -1){
			    player.stopMovement();
			    player.ready(0.3f);
			}else if(direction == 1 && (dir == 2 || dir == -2)){
			    player.stopMovement();
			    player.ready(0.3f);
			}
			
		}
	}

	void OnTriggerExit2d(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.UnLight ();
		}
	}
}
