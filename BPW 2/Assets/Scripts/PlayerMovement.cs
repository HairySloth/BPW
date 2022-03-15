using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public bool IsCrouching = false;
    public float CrouchHeight = 1.6f;
    public float Standingheight = 1.83f;

    Vector3 velocity;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        var groundMask = LayerMask.GetMask("Ground", "PickUp");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if(isGrounded && velocity.y < -3f)
        {
            velocity.y = -4f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

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

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
