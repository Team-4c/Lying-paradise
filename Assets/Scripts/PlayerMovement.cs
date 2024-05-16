using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float _horizontalMove = 0f;
	bool _jump = false;
	bool _crouch = false;

	public bool crouch = true;
	
	// Update is called once per frame
	void Update () {

		_horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			_jump = true;
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
