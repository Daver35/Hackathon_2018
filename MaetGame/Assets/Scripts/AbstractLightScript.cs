using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractLightScript : MonoBehaviour {

	public GameObject lightPoint;
	private bool light;
	private Rigidbody2D player;
	private InterfaceBlockController spriteChanger;

	// Use this for initialization
	void Start () {
		//lightPoint = GetComponent<GameObject> ();
		player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
		light = false;
		spriteChanger = gameObject.GetComponent<InterfaceBlockController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (light) {
			if (player.velocity.x != 0 || player.velocity.y != 0) {
				UnLight ();
			}
		}
	}

	//Turn on the lights
	public void Light(){
		lightPoint.SetActive (true);
		light = true;
		spriteChanger.changeSpriteLighted();
	}

	// Turn off the lights
	public void UnLight(){
		lightPoint.SetActive (false);
		light = false;
		spriteChanger.changeSpriteUnlighted();
	}

}
