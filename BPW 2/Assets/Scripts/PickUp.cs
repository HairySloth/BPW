using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject heldObj;
    public float pickUpRange = 5;
    public float pickUpRangeLarge = 50;
    public Transform holdParent;
    public float moveForce = 150;
    public bool superPickUp = true;
    public int minScale = -2;
    public int maxScale = 6;
    public float scaleSpeed = 0.1f;
    private bool gracePeriod = true;

    // Update is called once per frame



    void Update()
    {
        superPickUp = true;
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




        if (heldObj != null)
        {


            ScaleObject();
            MoveObject();
            if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 1f && gracePeriod == false)
            {
                DropObject();
            }
            //print(Vector3.Distance(heldObj.transform.position, holdParent.position));
        }
    




    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
            
        }
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) < 1f)
        {
            gracePeriod = false;
        }
    }

    void ScaleObject()
    {
        //print(scale);
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && heldObj.transform.localScale.y < 57f)
        {
            heldObj.transform.localScale = new Vector3((heldObj.transform.localScale.x * 1.1f), (heldObj.transform.localScale.y * 1.1f), (heldObj.transform.localScale.z * 1.1f));
            heldObj.GetComponent<Rigidbody>().mass = heldObj.GetComponent<Rigidbody>().mass * 1.2f;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && heldObj.transform.localScale.y > 16f)
        {
            heldObj.transform.localScale = new Vector3((heldObj.transform.localScale.x / 1.1f), (heldObj.transform.localScale.y / 1.1f), (heldObj.transform.localScale.z / 1.1f));
            heldObj.GetComponent<Rigidbody>().mass = heldObj.GetComponent<Rigidbody>().mass / 1.2f;
        }
        //print(heldObj.GetComponent<Rigidbody>().mass);
        //heldObj.transform.localScale = new Vector3 ((heldObj.transform.localScale.x * (Input.mouseScrollDelta.y+1)),(heldObj.transform.localScale.y *(Input.mouseScrollDelta.y+1)),(heldObj.transform.localScale.z * (Input.mouseScrollDelta.y+1)));

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
        gracePeriod = true;

    }
}
