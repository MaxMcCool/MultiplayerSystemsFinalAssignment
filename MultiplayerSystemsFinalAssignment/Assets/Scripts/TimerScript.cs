using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TimerScript : NetworkBehaviour
{

    private float startTime;
    private float elapsedTime;
    public Text timer;

    // Use this for initialization
    public override void OnStartServer()
    {
        Time.timeScale = 1.0f;
        startTime = 0;
        timer.text = elapsedTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime = Time.time - startTime;
        timer.text = "TIME: " + elapsedTime.ToString();

        if (elapsedTime >= 300.0f)
        {
            timer.text = "GAME OVER!!!";
            SceneManager.LoadScene("GameOverScene");
        }

    }
}