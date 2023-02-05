using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 3f;
    void Update()
    {
        transform.position += (Vector3)Vector2.down * speed * Time.deltaTime;
    }
}
