using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OtherScoreScript : NetworkBehaviour
{

    public int secondScore = 0;

    public Text scoreTwo;

    public override void OnStartServer()
    {
        scoreTwo.text = secondScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            secondScore++;
            scoreTwo.text = secondScore.ToString();
        }
    }
}
