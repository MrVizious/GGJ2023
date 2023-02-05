using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float secondsToCountdown = 2f;
    public SceneController sceneController;
    void Update()
    {
        secondsToCountdown -= Time.deltaTime;
        if (secondsToCountdown <= 0)
        {
            sceneController.LoadMainMenuScene();
        }
    }
}
