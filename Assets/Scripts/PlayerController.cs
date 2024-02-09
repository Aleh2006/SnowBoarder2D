using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float accelerationAmount = 1f;
    [SerializeField] float boostMultiplier = 5f; // Adjust this multiplier as needed
    [SerializeField] KeyCode boostKey = KeyCode.UpArrow; // Change to desired key for boosting
                                                         

    private Rigidbody2D rb2d;
    private Collider2D col;
    private SurfaceEffector2D surfaceEffector;
    private float originalSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // Find the SurfaceEffector2D component and apply acceleration
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
        if (surfaceEffector != null)
        {
            originalSpeed = surfaceEffector.speed;
        }
        else
        {
            Debug.LogWarning("No SurfaceEffector2D found in the scene.");
        }
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

        // Check for boost key input
        if (Input.GetKeyDown(boostKey))
        {
            BoostSpeed();
        }
    }

    void Update()
    {
        // Check if the player is grounded
        bool isGrounded = Physics2D.IsTouchingLayers(col, LayerMask.GetMask("Ground"));

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }

    void BoostSpeed()
    {
        if (surfaceEffector != null)
        {
            surfaceEffector.speed = originalSpeed * boostMultiplier;
            StartCoroutine(ResetSpeedAfterDelay());
        }
    }

    IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Adjust the delay as needed
        if (surfaceEffector != null)
        {
            surfaceEffector.speed = originalSpeed;
        }
    }
}
