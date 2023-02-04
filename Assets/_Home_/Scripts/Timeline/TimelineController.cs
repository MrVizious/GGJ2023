using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using TMPro;

public class TimelineController : MonoBehaviour
{
    /// <summary>
    /// Dictionary containing a reference to a list of historical events and the year they will happen
    /// </summary>

    // TODO: Change into some sort of game manager directed number
    [SerializeField] private float currentYear = 1469f;
    [SerializeField] private List<HistoricalEvent> historicalEvents;
    [SerializeField] private int totalSizeInYears = 50;
    [SerializeField] private TMP_Text text;
    private Dictionary<HistoricalEvent, GameObject> historicalEventsMarkers;
    private RectTransform rTransform;

    [SerializeField] private GameObject historicalEventMarkerPrefab;

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        currentYear += 2f * Time.deltaTime;
        text.text = Mathf.RoundToInt(currentYear).ToString();
        UpdateHistoricalEventsPositions();
    }
    private void Start()
    {
        if (historicalEventsMarkers == null)
        {
            historicalEventsMarkers = new Dictionary<HistoricalEvent, GameObject>();
        }
        foreach (var historicalEvent in historicalEvents)
        {
            GameObject newGO = Instantiate(historicalEventMarkerPrefab);
            newGO.transform.SetParent(transform);
            newGO.GetComponent<RectTransform>().localPosition = Vector2.zero;
            newGO.GetComponentInChildren<TMP_Text>().text = historicalEvent.yearOfExecution.ToString();
            historicalEventsMarkers.Add(historicalEvent, newGO);
        }
    }


    private void UpdateHistoricalEventsPositions()
    {
        foreach (var historicalEvent in historicalEventsMarkers.Keys)
        {
            historicalEventsMarkers[historicalEvent].GetComponent<RectTransform>().localPosition =
             new Vector2(rTransform.rect.width / totalSizeInYears * (historicalEvent.yearOfExecution - currentYear), 0);
        }
    }


}
