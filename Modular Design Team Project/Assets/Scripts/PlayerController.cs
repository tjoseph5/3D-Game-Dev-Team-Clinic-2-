using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some script credits to Brackeys https://www.youtube.com/watch?v=_QajrabyTJc

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 9.0f;
    public float gravity = -9.81f * 2;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if we are on the ground.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resets our velocity so it doesn't keep building up.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Assigns both axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Moves the player locally.
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}