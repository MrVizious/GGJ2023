using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Trail : MonoBehaviour
{
    private LineRenderer line;
    private void OnEnable()
    {
        line = GetComponent<LineRenderer>();
        Vector3[] startingLines = { transform.position, transform.position };
        if (line.positionCount < 3)
            line.SetPositions(startingLines);
    }
    void Update()
    {
        if (Vector3.Distance(line.GetPosition(line.positionCount - 1), transform.position) > .5f)
        {
            line.positionCount = line.positionCount + 1;
            line.SetPosition(line.positionCount - 1, transform.position);
        }
    }
}
