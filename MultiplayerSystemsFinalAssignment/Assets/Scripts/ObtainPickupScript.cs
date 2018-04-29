using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ObtainPickupScript : NetworkBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerScript>().transform.Translate(0, 0, Time.deltaTime * 6);
            Destroy(gameObject);
        }
    }
}
