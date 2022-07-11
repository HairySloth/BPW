using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public CharacterController player;
    public Transform playerReset;


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
        if (collider.GetComponent<CharacterController>())
        {
            player.enabled = false;
            player.transform.position = playerReset.transform.position;
            player.enabled = true;
            player.SimpleMove(Vector3.zero);
        }
    }
}