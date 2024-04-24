using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public float jumpForce = 5;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);


            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        sr.flipX = movement < 0 ? true : false;
    }


}
