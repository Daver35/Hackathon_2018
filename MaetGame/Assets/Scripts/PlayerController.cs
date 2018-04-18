using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity;
	private int direction;
	private bool isReady;
	private Rigidbody2D rigid;
	private float delay;

	//direction getter
	public int GetDirection() {
		return direction;
	}
	// Use this for initialization
	void Start () {
		isReady = true;
		rigid = GetComponent<Rigidbody2D> ();
		direction = 0;
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			
			float vert = Input.GetAxis ("Vertical");
			float hori = Input.GetAxis ("Horizontal");

			if (vert != 0) {
				direction  = (int)vert*2;
				rigid.velocity = new Vector2 (0, vert * velocity);
				isReady = false;
			} else if (hori != 0) {
				direction = (int)hori;
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

	public void SetReady(float delay){
		this.delay = delay;
	}

	public void StopMovement(){
		rigid.velocity = new Vector2 (0, 0);
		direction = 0;
	}
}
