using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isGrounded;
    Rigidbody2D rb2d;
    Collider2D collider2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

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
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        isGrounded = Physics2D.Raycast(collider2d.bounds.center, Vector2.down, collider2d.bounds.extents.y + 0.1f, LayerMask.GetMask("Ground")); // Используем Physics2D.Raycast

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Check if grounded and spacebar is pressed
        {
            Jump();
        }
    }

    void Jump()
    {
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}