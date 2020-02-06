using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PDollarGestureRecognizer;
using System;

public class SpellController : MonoBehaviour
{
    [SerializeField] private Transform gestureOnScreenPrefab;

    Camera cam;
    private Vector3 mousePos;


    private LineRenderer currentLineRenderer;
    private int vertexCount;
    private int strokeId = -1;

    private GameObject drawingPlane;

    private List<LineRenderer> gestureList;
    private List<Point> gesturePoints = new List<Point>();

    private List<Gesture> trainingSet = new List<Gesture>();

    private int gestureCount;

    // Start is called before the first frame update
    void Start()
    {
        drawingPlane = gameObject.transform.GetChild(0).gameObject;
        drawingPlane.SetActive(false);
        cam = Camera.main;

        gestureList = new List<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //start new spell
        {
            drawingPlane.SetActive(true);
            strokeId = -1;
        }

        if (Input.GetKeyUp(KeyCode.Space)) //end spell
        {
            drawingPlane.SetActive(false);
            destroyLines();

            Gesture candidate = new Gesture(gesturePoints.ToArray());
            foreach (Gesture gesture in trainingSet)
            {
                Result result = PointCloudRecognizer.Classify(candidate, new Gesture[] { gesture });
                Debug.Log("score of gesture " + result.GestureClass +": " + result.Score);
            }
        }

        if (Input.GetKey(KeyCode.Space)) //cast new spell
        {
            transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("add gesture " + gestureCount);
                Gesture newGesture = new Gesture(gesturePoints.ToArray(), gestureCount.ToString());
                trainingSet.Add(newGesture);

                string fileName = String.Format("{0}/{1}-{2}.xml", "C:/Users/Boesc/Desktop/", gestureCount.ToString(), DateTime.Now.ToFileTime());
                GestureIO.WriteGesture(gesturePoints.ToArray(), gestureCount.ToString(), fileName);

                ++gestureCount;
            }

            if (Input.GetMouseButtonDown(0)) //start new line
            {
                Transform tmpGesture = Instantiate(gestureOnScreenPrefab, transform.position, transform.rotation) as Transform;
                currentLineRenderer = tmpGesture.GetComponent<LineRenderer>();
                vertexCount = 0;

                gestureList.Add(currentLineRenderer);
                ++strokeId;
            }

            if (Input.GetMouseButton(0)) //draw current line
            {
                mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                //TODO: Refactor bounds to global variable (currently breaks the code if attempted)
                Bounds drawBounds = drawingPlane.GetComponent<SpriteRenderer>().bounds;

                //TODO: Refactor this condition into a seperate function
                if (!drawBounds.Contains(mousePos))
                {
                    //TODO: adjust this function to simply overwrite x and y instead of casting rays and intersecting them with the box
                    Vector3 dir = (mousePos - drawBounds.center).normalized;
                    Ray ray = new Ray(drawBounds.center, dir);
                    drawBounds.IntersectRay(ray, out float distance);
                    mousePos = drawBounds.center - dir * distance;
                }

                currentLineRenderer.positionCount = ++vertexCount;
                currentLineRenderer.SetPosition(vertexCount - 1, mousePos);

                gesturePoints.Add(new Point(mousePos.x, mousePos.y, strokeId));

            }
        } 
    }

    //TODO: Find a more elegant way to destroy Line Clones
    private void destroyLines()
    {
        List<GameObject> lines = new List<GameObject>(GameObject.FindGameObjectsWithTag("Line"));

        foreach (GameObject l in lines)
        {
            Destroy(l);
        }
    }
}
