using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EdgeCollider2D))]

public class ColliderForLine : MonoBehaviour
{

    EdgeCollider2D edgeCollider2D;
    LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        edgeCollider2D = this.GetComponent<EdgeCollider2D>();
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetEdgeCollider(lineRenderer);
    }


    void SetEdgeCollider(LineRenderer currentLineRendered)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < currentLineRendered.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        
        }

        edgeCollider2D.SetPoints(edges);
    }
}
