using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HistoricalEventGoat", menuName = "HistoricalEvents/Goat", order = 0)]
public class HistoricalEventGoat : HistoricalEvent
{
    public override void Execute()
    {
        Debug.Log("Heeeey");
    }
}
