using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HistoricalEvent : ScriptableObject
{
    [SerializeField] private string eventName;
    [SerializeField] public int minYear, maxYear;
    public int yearOfExecution = 0;
    private void SetYearOfExecution(int year = -1)
    {
        if (year != -1)
        {
            yearOfExecution = year;
        }
        else
            yearOfExecution = (int)Random.Range(minYear, maxYear + 1);
    }
    public abstract void Execute();
    private void OnEnable()
    {
        SetYearOfExecution();
    }
}