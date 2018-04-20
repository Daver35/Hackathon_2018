using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBlockController : MonoBehaviour, InterfaceBlockController {

	private AbstractLightScript lightSys;
	public Orientation orientation;
	public AudioClip hitSound;
	public Sprite unlighted, lighted;

	// Use this for initialization
	void Start () {
		lightSys = GetComponent<AbstractLightScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.Light ();
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			player.BlockDirection(DirectionF.rotateDirection(player.direction, orientation));	
			player.StopMovement ();
			player.SetReady (1f);
			SoundManager.instance.PlaySingle (hitSound);
		}
	}

	/*void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			lightSys.UnLight ();
		}
	}*/

	public void changeSpriteLighted(){
		this.GetComponent<SpriteRenderer> ().sprite = lighted;
	}
	public void changeSpriteUnlighted(){
		this.GetComponent<SpriteRenderer> ().sprite = unlighted;
	}
}
