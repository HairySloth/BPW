using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropFlyFix : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;



    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, mask);

        if(isGrounded == false)
        {
            gameObject.layer = 0;
        }

        if(isGrounded == true)
        {
            gameObject.layer = 0;
        }

    }
}
