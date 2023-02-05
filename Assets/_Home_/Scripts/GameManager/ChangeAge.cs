using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class ChangeAge : MonoBehaviour
{
    public GameEvent nextAgeGameEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Camera"))
        {
            nextAgeGameEvent.Raise();
        }
    }
}
