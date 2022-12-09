using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    private int points;

    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int point)
    {
        points += point;
        Debug.Log(points);
    }
}
