using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBlockController : MonoBehaviour {

	private Direction exitDirection;
	public AudioClip hitSound1;
	public AudioClip hitSound2;

	// Use this for initialization
	void Start () {
		if (this.transform.rotation.eulerAngles.y == 0) {
			exitDirection = Direction.Down;
		} else if (this.transform.rotation.eulerAngles.y == 90) {
			exitDirection = Direction.Left;
		} else if (this.transform.rotation.eulerAngles.y == 180) {
			exitDirection = Direction.Up;
		} else if (this.transform.rotation.eulerAngles.y == 270) {
			exitDirection = Direction.Right;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log ("hit player");
		if (collision.gameObject.CompareTag ("Player")) {
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			Direction dir = player.GetDirection();
			if(dir == exitDirection){
				//Finish level
				Debug.Log ("Exit level");
				player.StopMovement();
				player.SetReady(1f);
				SoundManager.instance.PlaySingle (hitSound2);
			}else{
				player.StopMovement();
				player.SetReady(1f);
				SoundManager.instance.PlaySingle (hitSound1);
			}

		}
	}
}
