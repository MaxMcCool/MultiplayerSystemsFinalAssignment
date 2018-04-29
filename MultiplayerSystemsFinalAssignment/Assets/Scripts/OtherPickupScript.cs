using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OtherPickupScript : NetworkBehaviour
{

    public GameObject pickupPrefab;

    public override void OnStartServer()
    {
        var spawnPosition = new Vector3(Random.Range(-12.0f, 12.0f), 0.0f, Random.Range(-12.0f, 12.0f));
        var spawnRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);

        var pickup = (GameObject)Instantiate(pickupPrefab, spawnPosition, spawnRotation);
        NetworkServer.Spawn(pickup);
    }
}

