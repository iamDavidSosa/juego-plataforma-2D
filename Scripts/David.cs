using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class David : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 250;
    private Rigidbody2D rigidbody2D;
    private Animator animator; 
    float horizontal;
    public bool isGrounded = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Jumping();
        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        animator.SetBool("Running", horizontal != 0.0f);


        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f).collider != null)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    // FixedUpdate is called once per frame 
    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * speed, rigidbody2D.linearVelocity.y);
    }

    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    void Jumping()
    {
        if (isGrounded)
        {
            animator.SetBool("Jumping", false);
        }
        else
        {
            animator.SetBool("Jumping", true);
        }
        
    }
}
