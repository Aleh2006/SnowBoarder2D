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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }

        // Check if the player is grounded
        isGrounded = Physics2D.IsTouchingLayers(col, LayerMask.GetMask("Ground"));

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Check if grounded and spacebar is pressed
        {
            Jump();
        }
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }
}