using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBlockController : MonoBehaviour {

	private AbstractLightScript aLightSys;
	private DelayLightController dLightSys;
	public Axis direction;
	public AudioClip hitSound1;
	public AudioClip hitSound2;

	public enum Axis{
		Horitzontal,
		Vertical
	}
	// Use this for initialization
	void Start () {
		dLightSys = GetComponent<DelayLightController> ();
		aLightSys = GetComponent<AbstractLightScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log ("hit player");
		if (collision.gameObject.CompareTag ("Player")) {
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			Direction dir = player.GetDirection();
			if (direction == Axis.Horitzontal && (dir == Direction.Up || dir == Direction.Down)) {
				player.StopMovement ();
				player.SetReady (1f);
				SoundManager.instance.PlaySingle (hitSound1);
				aLightSys.Light ();

			} else if (direction == Axis.Vertical && (dir == Direction.Right || dir == Direction.Left)) {
				player.StopMovement ();
				player.SetReady (1f);
				SoundManager.instance.PlaySingle (hitSound1);
				aLightSys.Light ();

			} else {
				SoundManager.instance.PlaySingle (hitSound2);
				dLightSys.Light ();
			}
			
		}
	}

	/*void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.UnLight();
		}
	}*/
}
