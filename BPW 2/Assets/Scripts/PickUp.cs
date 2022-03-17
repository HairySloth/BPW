using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject heldObj;
    public float pickUpRange = 5;
    public float pickUpRangeLarge = 50;
    public Transform holdParent;
    public float moveForce = 150;
    public bool superPickUp = false;


    // Update is called once per frame



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                LayerMask mask = LayerMask.GetMask("PickUp");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, mask))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            } 
            else
            {
                DropObject();
            }
        }

        if (superPickUp == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (heldObj == null)
                {
                    LayerMask mask = LayerMask.GetMask("PickUp");

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRangeLarge, mask))
                    {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
                else
                {
                    DropObject();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            if (superPickUp == false)
            {
                superPickUp = true; 
            }
            else
            {
                superPickUp = false;
            }
        }



        if (heldObj != null)
        {
            MoveObject();
        }
    
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
            
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;
            objRig.angularDrag = 1;
            objRig.mass = objRig.mass * 5;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;

        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;
        heldRig.angularDrag = 0.05f;
        heldRig.mass = heldRig.mass / 5;

        heldObj.transform.parent = null;
        heldObj = null;

    }
}
