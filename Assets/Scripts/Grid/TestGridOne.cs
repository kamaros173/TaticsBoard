using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridOne : MonoBehaviour {

    public Grid grid;
	
	// Update is called once per frame
	void Update () {
        //List<GridSquare> derp = grid.GetNeighbors(transform.position, 3);
        //foreach(GridSquare n in derp)
        //{
        //    n.active = false;
        //}

        GridSquare n = grid.GetCorner(transform.position);
        n.active = false;
        


    }
}
