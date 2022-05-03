using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed;
    public Transform buttonCheck;
    public float buttonDistance;
    public Animator slideDoor = null;
    public bool hasBeenOpened;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var buttonMask = LayerMask.GetMask("PickUp");
        isPressed = Physics.CheckSphere(buttonCheck.position, buttonDistance, buttonMask);
        if (isPressed)
        {
            slideDoor.Play("SliderDoorOpen");
            hasBeenOpened = true;

        }
        else if (isPressed == false && hasBeenOpened)
        {
            slideDoor.Play("SliderDoorClose");
        }


    }
}
