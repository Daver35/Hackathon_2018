using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBlockController : MonoBehaviour {

	public int level;
	private Direction exitDirection;
	public AudioClip hitSound1;
	public AudioClip hitSound2;

	// Use this for initialization
	void Start () {
		if (this.transform.rotation.eulerAngles.z == 0) {
			exitDirection = Direction.Down;
		} else if (this.transform.rotation.eulerAngles.z == 90) {
			exitDirection = Direction.Right;
		} else if (this.transform.rotation.eulerAngles.z == 180) {
			exitDirection = Direction.Up;
		} else if (this.transform.rotation.eulerAngles.z == 270) {
			exitDirection = Direction.Left;
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

				Debug.Log ("Exit level"+ (level+1));
				player.StopMovement();
				player.SetReady(1f);
				SoundManager.instance.PlaySingle (hitSound2);
				if (level == 4) {
					SceneManager.LoadScene("Credits");
				} else {
					SceneManager.LoadScene("level_"+(level+1));
				}

			}else{
				player.StopMovement();
				player.SetReady(1f);
				SoundManager.instance.PlaySingle (hitSound1);
			}

		}
	}
}
