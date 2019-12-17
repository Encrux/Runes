using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;

public class GestureRecognizer
{
    private Gesture g;
    private Gesture[] trainingSet;

    public GestureRecognizer()
    {
       
    }

    public int Recognize(List<Vector2> points)
    {
        return 0;
    }

    public void addGesture(List<Vector2> points)
    {
       
    }

    //converts list of vector2 to Points
    private Point[] ConvertVector2ToPoint(List<Vector2> points)
    {
        Point[] gesturePoints = new Point[points.Count];
        for (int i = 0; i < points.Count - 1;)
        {
            gesturePoints[i] = new Point(points[i].x, points[i].y, 0);
        }

        return gesturePoints;
    }
}
