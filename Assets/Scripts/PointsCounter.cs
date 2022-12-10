using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    public TextMeshProUGUI visualPoints;
    private float points;

    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points = Time.deltaTime;
        visualPoints.text = points.ToString();
    }

    public void AddPoints(int point)
    {
        points += point;
        Debug.Log(points);
    }
}
