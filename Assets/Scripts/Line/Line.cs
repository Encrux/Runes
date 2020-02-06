using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private static readonly double MINUMUM_DISTANCE = .001f;
    public LineRenderer lineRenderer;
    private Material material;
    List<Vector2> points;
    private int pointsInLetterCount;

    //starts a new line and adds new points if the mouse traveled far enough
    public void updateLine(Vector2 mousePos)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            AddPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(),  mousePos) > MINUMUM_DISTANCE)
        {
            AddPoint(mousePos);
        }
    }

    //adds a new line according to the mouse cursor (e.g. drawing)
    private void AddPoint(Vector2 mousePos)
    {
        points.Add(mousePos);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, mousePos);
    }

    //returns the list of points
    public List<Vector2> getPoints()
    {
        return this.points;
    }
 
}
