using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ObtainSlowPickupScript : NetworkBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerScript>().transform.Translate(0, 0, Time.deltaTime * 1.5f);
            Destroy(gameObject);
        }
    }
}
