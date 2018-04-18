using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity;
	private Direction _direction;
	public Direction direction{
		get{ return this._direction;}
	}
	private bool isReady;
	private Rigidbody2D rigid;
	private float delay;
	private bool blockedUp, blockedDown, blockedLeft, blockedRight;
	private Animator animator;

	//direction getter
	public Direction GetDirection() {
		return _direction;
	}
	// Use this for initialization
	void Start () {
		blockedUp = false; blockedDown = false; blockedLeft = false; blockedRight = false;
		animator = GetComponent<Animator> ();
		isReady = true;
		rigid = GetComponent<Rigidbody2D> ();
		_direction = 0;
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			
			float vert = Input.GetAxis ("Vertical");
			float hori = Input.GetAxis ("Horizontal");
			if (vert != 0 || hori != 0) {
				if (vert != 0) {
					if (vert > 0) {
						_direction = Direction.Up;
					}else{
						_direction = Direction.Down;
					}
				} else{
					if (hori > 0) {
						_direction = Direction.Right;
					} else {
						_direction = Direction.Left;
					}
				}
				Move (_direction);
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
		if (!blockedUp) {
			rigid.velocity = new Vector2 (0, velocity);
			animator.SetTrigger ("playerVertical");
			transform.localScale = new Vector3 (1f, 1f, 1f);
			isReady = false;
			blockedUp = false; blockedDown = false; blockedLeft = false; blockedRight = false;
			_direction = Direction.Up;
		}
	}
	public void MoveDown(){
		if (!blockedDown) {
			rigid.velocity = new Vector2 (0, -velocity);
			animator.SetTrigger ("playerVertical");
			transform.localScale = new Vector3 (1f, -1f, 1f);
			isReady = false;
			blockedUp = false; blockedDown = false; blockedLeft = false; blockedRight = false;
			_direction = Direction.Down;
		}
	}
	public void MoveRight(){
		if (!blockedRight) {
			rigid.velocity = new Vector2 (velocity, 0);
			animator.SetTrigger ("playerHoritzontal");
			transform.localScale = new Vector3 (1f, 1f, 1f);
			isReady = false;
			blockedUp = false; blockedDown = false; blockedLeft = false; blockedRight = false;
			_direction = Direction.Right;
		}
	}
	public void MoveLeft(){
		if (!blockedLeft) {
			rigid.velocity = new Vector2 (-velocity, 0);
			animator.SetTrigger ("playerHoritzontal");
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			isReady = false;
			blockedUp = false; blockedDown = false; blockedLeft = false; blockedRight = false;
			_direction = Direction.Left;
		}
	}

	public void desplaceOffset(Direction dir, float offset){
		if(dir == Direction.Up ){
			transform.position += new Vector3 (0,offset,0);
		}else if(dir == Direction.Down){
			transform.position += new Vector3 (0,-offset,0);
		}else if(dir == Direction.Right){
			transform.position += new Vector3 (offset,0,0);
		}else if(dir == Direction.Left){
			transform.position += new Vector3 (-offset,0,0);
		}
	}

	public void StopMovement(){
		desplaceOffset (_direction, -0.25f);
		BlockDirection (_direction);
		rigid.velocity = new Vector2 (0, 0);
		_direction = Direction.Center;
		animator.SetTrigger ("playerHit");
	}

	public Direction directionFromVector(Vector2 vector){
		if (vector.x > 0) {
			return Direction.Right;
		} else if (vector.x < 0) {
			return Direction.Left;
		} else if (vector.y > 0) {
			return Direction.Up;
		} else if (vector.y < 0) {
			return Direction.Down;
		} else {
			return Direction.Center;
		}
	}

	public void BlockDirection(Direction direction){
		if (direction == Direction.Up){
			blockedUp = true;
		}else if(direction == Direction.Down){
			blockedDown = true;
		}else if(direction == Direction.Right){
			blockedRight = true;
		}else if(direction == Direction.Left){
			blockedLeft = true;
		}
	}

	public void Move(Direction direction){
		if (direction == Direction.Up){
			MoveUp ();
		}else if(direction == Direction.Down){
			MoveDown();
		}else if(direction == Direction.Right){
			MoveRight ();
		}else if(direction == Direction.Left){
			MoveLeft ();
		}
	}
}
