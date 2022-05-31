using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float jumpPadJumpHeight = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public bool IsCrouching = false;
    public float CrouchHeight = 1f;
    public float Standingheight = 1.83f;
    public float maxInitialFallSpeed = -4f;

    Vector3 velocity;
    public bool isGrounded;
    public bool isOnJumpPad;
    public float z;
    public float x;
    public float acceleration = 1f;


    // Update is called once per frame
    void Update()
    {
        var groundMask = LayerMask.GetMask("Ground", "PickUp");
        var jumpPadMask = LayerMask.GetMask("JumpPad");
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnJumpPad = Physics.CheckSphere(groundCheck.position, groundDistance, jumpPadMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");



        Vector3 move = transform.right * x + transform.forward * z;

        if(velocity.y < maxInitialFallSpeed && isGrounded)
        {
            velocity.y = maxInitialFallSpeed;
        }
        if(velocity.y < maxInitialFallSpeed && isOnJumpPad)
        {
            velocity.y = maxInitialFallSpeed;
        }

        
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouching = true;
        }
        else
        {
            IsCrouching = false;
        }

        if (IsCrouching == true)
        {
            controller.height = CrouchHeight;
        }
        else
        {
            controller.height = Standingheight;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetButtonDown("Jump")&& isOnJumpPad)
        {
            velocity.y = Mathf.Sqrt(jumpPadJumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);   
    }
}
