using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlagPickUpScript : NetworkBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerScript>().flagIsHeld = true;
            Destroy(gameObject);
        }
    }
}
