using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlagScript : NetworkBehaviour
{
    public GameObject flagPrefab;


    public override void OnStartServer()
    {
        var spawnPosition = new Vector3(Random.Range(-11.0f, 11.0f), 0.0f, Random.Range(-11.0f, 11.0f));
        var spawnRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);

        var flag = (GameObject)Instantiate(flagPrefab, spawnPosition, spawnRotation);
        NetworkServer.Spawn(flag);
    }
}
