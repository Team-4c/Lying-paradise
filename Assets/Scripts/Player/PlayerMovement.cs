using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float _horizontalMove = 0f;
	bool _jump = false;
	bool _crouch = false;

	private bool _air;

	private Animator _anim;

	public bool crouch = true;

	private void Start()
	{
		_anim = GetComponentInChildren<Animator>();
	}

	void Update () {

		_horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Jump"))
		{
			_jump = true;
		}

		if (_horizontalMove != 0)
		{
			_anim.Play("run");
		}

		if (_horizontalMove == 0)
		{
			_anim.Play("idle");
		}

		if (crouch != false)
		{
			if (Input.GetButtonDown("Crouch"))
			{
				_crouch = true;
			}
			else if (Input.GetButtonUp("Crouch"))
			{
				_crouch = false;
			}
		}
	}
	

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
		_jump = false;
	}
}
