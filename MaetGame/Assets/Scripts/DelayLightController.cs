using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayLightController : MonoBehaviour {

	public GameObject lightPoint;
	public float delay;
	private InterfaceBlockController spriteChanger;

	// Use this for initialization
	void Start () {
		spriteChanger = gameObject.GetComponent<InterfaceBlockController> ();
	}

	// Update is called once per frame
	void Update () {
	}

	//Turn on the lights
	public void Light(){
		lightPoint.SetActive (true);
		Invoke ("UnLight",delay);
		spriteChanger.changeSpriteLighted();
	}

	// Turn off the lights
	public void UnLight(){
		lightPoint.SetActive (false);
		spriteChanger.changeSpriteUnlighted();
	}

}
