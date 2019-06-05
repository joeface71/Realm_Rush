using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // script executes while editing
[SelectionBase] // default selection in editor is cube--prevents accidentally selecting something else
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();        
        transform.position = new Vector3(
            waypoint.GetGridPos().x, 
            0f,
            waypoint.GetGridPos().y
        );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            waypoint.GetGridPos().x / gridSize + 
            "," + 
            waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText; // renames to coords
    }
}
