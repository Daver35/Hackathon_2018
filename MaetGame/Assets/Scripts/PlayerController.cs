using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity;
	private Direction direction;
	private bool isReady;
	private Rigidbody2D rigid;
	private float delay;
	private bool BlockedUp, BlockedDown, BlockedLeft, BlockedRight;
	private Animator animator;
	public enum Direction
	{
		up,
		down,
		left,
		right,
		center
	};

	//direction getter
	public Direction GetDirection() {
		return direction;
	}
	// Use this for initialization
	void Start () {
		BlockedUp = false; BlockedDown = false; BlockedLeft = false; BlockedRight = false;
		animator = GetComponent<Animator> ();
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
			Debug.Log("Ready :)");
			if (vert != 0 || hori != 0) {
				Vector2 vectorDirection = new Vector2(0,0);
				if (vert != 0) {
					vectorDirection = new Vector2 (0, vert);
					isReady = false;
				} else if (hori != 0) {
					vectorDirection = new Vector2 (hori, 0);
					isReady = false;
				}
				direction = directionFromVector (vectorDirection);
				Move (direction);
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

	public void MoveUp(){
		if (!BlockedUp) {
			rigid.velocity = new Vector2 (0, velocity);
			animator.SetTrigger ("playerVertical");
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}
	public void MoveDown(){
		if (!BlockedDown) {
			rigid.velocity = new Vector2 (0, -velocity);
			animator.SetTrigger ("playerVertical");
			transform.localScale = new Vector3 (1f, -1f, 1f);
		}
	}
	public void MoveRight(){
		if (!BlockedRight) {
			rigid.velocity = new Vector2 (velocity, 0);
			animator.SetTrigger ("playerHoritzontal");
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}
	public void MoveLeft(){
		if (!BlockedLeft) {
			rigid.velocity = new Vector2 (-velocity, 0);
			animator.SetTrigger ("playerHoritzontal");
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	public void StopMovement(){
		rigid.velocity = new Vector2 (0, 0);
		direction = Direction.center;
		animator.SetTrigger ("playerHit");
	}

	public Direction directionFromVector(Vector2 vector){
		if (vector.x > 0) {
			return Direction.right;
		} else if (vector.x < 0) {
			return Direction.left;
		} else if (vector.y > 0) {
			return Direction.up;
		} else if (vector.y < 0) {
			return Direction.down;
		} else {
			return Direction.center;
		}
	}

	public void BlockDirection(Direction direction){
		if (direction == Direction.up){
			
		}else if(direction == Direction.down){
			
		}else if(direction == Direction.right){

		}else if(direction == Direction.left){

		}
	}

	public void Move(Direction direction){
		if (direction == Direction.up){
			MoveUp ();
		}else if(direction == Direction.down){
			MoveDown();
		}else if(direction == Direction.right){
			MoveRight ();
		}else if(direction == Direction.left){
			MoveLeft ();
		}
	}
}
