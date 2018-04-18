using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBlockController : MonoBehaviour {
	
	private AbstractLightScript lightSys;
	public Axis direction;

	public enum Axis{
		Horitzontal,
		Vertical
	}
	// Use this for initialization
	void Start () {
		lightSys = GetComponent<AbstractLightScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log ("hit player");
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.Light ();
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			Direction dir = player.GetDirection();
			if(direction == Axis.Horitzontal && (dir == Direction.Up || dir == Direction.Down)){
			    player.StopMovement();
			    player.SetReady(1f);
			}else if(direction == Axis.Vertical && (dir == Direction.Right || dir == Direction.Left)){
			    player.StopMovement();
			    player.SetReady(1f);
			}
			
		}
	}

	/*void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.UnLight();
		}
	}*/
}
