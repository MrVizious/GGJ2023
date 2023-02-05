using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Character"))
        {
            if (other.GetComponent<CharacterController>().GetHighestBloodPercentage() < .75f)
                GameManager.Instance.GameOver();
        }
    }
}
