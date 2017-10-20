using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour {

    public Vector3 Location { get; set; }
    public Vector3 GridIndex { get; set; }
    public bool active;

    public GridSquare(Vector3 position, Vector3 index)
    {
        Location = position;
        GridIndex = index;
        active = true;
    }
}
