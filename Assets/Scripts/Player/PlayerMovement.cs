using UnityEngine;


namespace Player
{
	public class PlayerMovement : MonoBehaviour
	{

		public float IdleSensitivity = 0.01f;
		
		public CharacterController2D controller;

		public float runSpeed = 40f;

		float _horizontalMove = 0f;
		bool _jump = false;
		bool _crouch = false;

		private bool _climb;
		public LayerMask loadder;
		public Transform climbCheck;
		private float _climbRadius = .2f;

		private bool _air;

		private Animator _anim;

		public bool crouch = true;

		public positon pos;

		private void Start()
		{
			_anim = GetComponentInChildren<Animator>();

			pos.position = transform.position;
		}

		void Update () {

			_horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			if (Input.GetButtonDown("Jump"))
			{
				_jump = true;
			}

			if (controller.mGrounded && !_climb)
			{
				
				if (Mathf.Abs(_horizontalMove) > IdleSensitivity)
				{
					_anim.Play("run");
				}
				else _anim.Play("idle");
			}
			if (!controller.mGrounded)
			{
				if (_climb != true)
				{
					_anim.Play("jump");
				}
				
				if (Physics2D.OverlapCircle(climbCheck.position, _climbRadius, loadder))
				{
					if (Input.GetButton("Vertical"))
					{
						_climb = true;
						_anim.Play("climb");
					}
					else
					{
						_anim.Play("climbIdle");
					}
				}
				else
				{
					_climb = false;
				}
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

			if (Physics2D.OverlapCircle(controller.m_GroundCheck.position, controller.k_GroundedRadius, loadder))
			{
				_anim.Play("climb");
			}
		}
	

		void FixedUpdate ()
		{
			// Move our character
			controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
			_jump = false;
			
		}
	}
    
}
