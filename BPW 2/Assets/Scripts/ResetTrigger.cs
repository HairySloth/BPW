using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public Transform resetPoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider collider)
    {
       if (collider.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = collider.GetComponent<Rigidbody>();
            objRig.transform.position = resetPoint.transform.position;
            objRig.velocity = new Vector3 (0, 0, 0);

        }
    }
}
