using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded;
    Rigidbody2D rb2d;
    Collider2D col;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.IsTouchingLayers(col, LayerMask.GetMask("Ground"));

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }
}