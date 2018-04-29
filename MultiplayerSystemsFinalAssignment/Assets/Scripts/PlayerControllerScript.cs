using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerScript : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public GameObject playerFlag;
    public bool flagIsHeld;

	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

        if(!flagIsHeld)
        {
            playerFlag.SetActive(false);
        }
        else
        {
            playerFlag.SetActive(true);
            //playerFlag.GetComponentInChildren<Renderer>().enabled = true;
        }
    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Flag"))
        {
            
            flagIsHeld = true;
            playerFlag.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        flagIsHeld = false;
    }
}
