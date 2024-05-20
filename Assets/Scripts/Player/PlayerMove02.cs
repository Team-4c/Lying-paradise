using UnityEngine;

public class PlayerMove02 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float stopDamping = 0.2f;

    [Header("Jump Settings")]
    public float jumpForce = 10f;
    public float wallJumpForce = 7f;

    [Header("Layer Masks")]
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        CheckGround();
        MovePlayer();
        CheckJump();
        SmoothStop();
    }

    private void CheckInput()
    {
        moveInput = Input.GetAxis("Horizontal");
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, wallLayer) || Physics2D.Raycast(transform.position, Vector2.left, 0.1f, wallLayer);
        isWallSliding = !isGrounded && isTouchingWall;
    }

    private void MovePlayer()
    {
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump(jumpForce);
            }
            else if (isWallSliding)
            {
                if (moveInput != 0)
                {
                    JumpOffWall(wallJumpForce);
                }
            }
        }
    }

    private void Jump(float force)
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
        }
    }

    private void JumpOffWall(float force)
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(-Mathf.Sign(moveInput) * force, jumpForce);
        }
    }

    private void SmoothStop()
    {
        if (moveInput == 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * stopDamping, rb.velocity.y);
        }
    }
}