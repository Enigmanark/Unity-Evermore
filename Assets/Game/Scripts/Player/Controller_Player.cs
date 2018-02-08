using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour {
	public float moveSpeed = 10F;
	private Animator animator;
	private Rigidbody2D rgb;
	private bool moving = false;
	private float moveX;
	private float moveY;
	private Vector2 lastMove;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
		rgb = GetComponent<Rigidbody2D>();
		lastMove = new Vector2(0, -1);
	}

	// Update is called once per frame
	void Update() {
		GetIntendedMove();
		UpdateAnim();
		ApplyMovement();
	}

	private float GetMoveX()
	{
		return Input.GetAxis("Horizontal");
	}

	private float GetMoveY()
	{
		return Input.GetAxis("Vertical");
	}

	private void UpdateAnim()
	{
		animator.SetBool("moving", moving);
		if(moveX != 0) { animator.SetFloat("moveY", 0f);  }
		else animator.SetFloat("moveY", moveY);
		animator.SetFloat("moveX", moveX);
		animator.SetFloat("lastMoveX", lastMove.x);
		animator.SetFloat("lastMoveY", lastMove.y);
	}

	private void ApplyMovement()
	{
		Vector3 movePos = new Vector3(moveX, moveY, 0);
		rgb.velocity = movePos;
	}

	public Vector2 GetLastMove()
	{
		return lastMove;
	}

    private void GetIntendedMove()
    {
		moveX = GetMoveX();
		moveY = GetMoveY();
		if(moveX != 0 || moveY != 0)
		{
			
			moveX *= moveSpeed;
			moveY *= moveSpeed;
			moving = true;
			lastMove = new Vector2(moveX, moveY);
		}
		else
		{
			moving = false;
		}
    }
}
