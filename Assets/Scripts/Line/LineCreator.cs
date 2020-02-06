using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    Line activeLine;
    GameObject lineGO;
    GameObject recordedLineGO;
    bool recording;

    private void Start()
    {
    }

    private void Update()
    {

        //starts recording the next line drawn
        if (Input.GetKeyDown(KeyCode.R))
        {
            recording = true;
            print("recording");
        }

        //outputs the last drawn line (error, if no line was recorded)
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(recordedLineGO == null)
            {
                print("no line recorded");
               
            } else
            {
                recordedLineGO.SetActive(true);
            }
        }

        //deletes the last recorded line
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(GameObject.Find("recordedLine"));
        }


        //starts drawing a new line
        if (Input.GetMouseButtonDown(0))
        {
            lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();
        }

        //stops drawing the new line
        if(Input.GetMouseButtonUp(0))
        {
            if(recording == true)
            {
                recording = false;
                print("successfully recorded");
                lineGO.SetActive(false);
                lineGO.name = "recordedLine";
                recordedLineGO = lineGO;
            } else
            {
                Destroy(lineGO);
            }

            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.updateLine(mousePos);
        }

    }
}
