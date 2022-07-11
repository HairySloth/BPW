using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public GameObject camera;
    public GameObject CrosshairObject;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        PickUp pickUp = camera.GetComponent<PickUp>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     if(camera.GetComponent<PickUp>().heldObj == null)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
