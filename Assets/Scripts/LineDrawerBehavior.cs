using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineDrawerBehavior : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Vector2 mousePos;
    public Vector2 startMousePos;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraPositioning.gameStarted == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }


            if (Input.GetMouseButton(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, -5f));
                lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -5f));

            }

        }

    }

    public void RestartLineDrawn()
    {
        lineRenderer.SetPosition(0, new Vector3(-1800, -1800, -5f));
        lineRenderer.SetPosition(1, new Vector3(-1801, -1801, -5f));

    }
}
