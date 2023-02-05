using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float downSpeed = 3f, upSpeed = 2f;
    public SceneController sceneController;

    private Vector3 initialPosition;
    public bool goingDown = true;
    private void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        if (goingDown)
            transform.position += (Vector3)Vector2.down * downSpeed * Time.deltaTime;
        else
        {
            transform.position -= (Vector3)Vector2.down * upSpeed * Time.deltaTime;
            if (transform.position.y >= initialPosition.y)
            {

                sceneController.LoadMainMenuScene();
                Debug.Log("Game Ended");
            }
        }
    }
}
