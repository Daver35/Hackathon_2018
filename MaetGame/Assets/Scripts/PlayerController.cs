using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity;
	private bool isReady;
	private Rigidbody2D rigid;
	private float delay = 0;

	// Use this for initialization
	void Start () {
		Debug.Log("Start player");
		isReady = true;
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Detectat" + isReady);
		if (isReady) {
			
			float vert = Input.GetAxis ("Vertical");
			float hori = Input.GetAxis ("Horizontal");

			if (vert != 0) {
				rigid.velocity = new Vector2 (0, vert * velocity);
				isReady = false;
				Debug.Log ("Detectat");
			} else if (hori != 0) {
				rigid.velocity = new Vector2 (hori * velocity, 0);
				isReady = false;
			}
		} else if(delay > 0 ){
			delay -= Time.deltaTime;
			if(delay <= 0){
				isReady = true;
			}
		}
	}

	void SetReady(float delay){
		this.delay = delay;
	}
}
