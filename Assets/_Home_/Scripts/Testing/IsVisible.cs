using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class IsVisible : MonoBehaviour
{
    Renderer r;
    private void Start()
    {
        r = GetComponent<Renderer>();
    }
    private void Update()
    {
        Debug.Log(r.isVisible);
    }
}
