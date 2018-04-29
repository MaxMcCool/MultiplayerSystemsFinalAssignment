using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScoreScript : NetworkBehaviour {

    public int firstScore = 0;

    public Text scoreOne;

    public override void OnStartServer()
    {
        scoreOne.text = firstScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            firstScore++;
            scoreOne.text = firstScore.ToString();
        }
    }
}
