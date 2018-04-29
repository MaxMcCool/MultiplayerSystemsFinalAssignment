﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<HealthScript>();
        if(health != null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);

        hit.GetComponent<PlayerControllerScript>().flagIsHeld = false;
    }

}
