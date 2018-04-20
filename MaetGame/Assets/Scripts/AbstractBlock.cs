using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractBlock : MonoBehaviour {

	public AudioClip hitSound;
	public Sprite unlighted, lighted;
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
			SoundManager.instance.PlaySingle (hitSound);
		}
	}

	public void changeSpriteLighted(){
		this.GetComponent<SpriteRenderer> ().sprite = lighted;
	}
	public void changeSpriteUnlighted(){
		this.GetComponent<SpriteRenderer> ().sprite = unlighted;
	}

	/*void OnTriggerExit2D(Collider2D collider) {
		if (collider.CompareTag ("Player")) {
			lightSys.UnLight ();
		}
	}*/
}
