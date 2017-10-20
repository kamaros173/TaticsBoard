using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    
    public int GridX { get; set; }
    public int GridY { get; set; }
    public int GridZ { get; set; }

    private GridSquare[,,] grid;
    private GridSquare[,,] corners;

    public GridSquare GetSquare(Vector3 pos)
    {
        pos -= transform.position;
        int x = Mathf.RoundToInt(pos.x) + GridX / 2;
        int y = Mathf.RoundToInt(pos.y) + GridY / 2;
        int z = Mathf.RoundToInt(pos.z) + GridZ / 2;

        //SHOULD CHECK FOR OUTOFBOUNDS
        return grid[x, y, z];

    }

    public GridSquare GetCorner(Vector3 pos)
    {
        pos += Vector3.one * 0.5f;
        GridSquare square = GetSquare(pos);

        //SHOULD CHECK FOR OUTOFBOUNDS
        return corners[(int)square.GridIndex.x - 1, (int)square.GridIndex.y-1, (int)square.GridIndex.z-1];
    }

    public List<GridSquare> GetNeighborSquares(Vector3 pos, int distance = 1)
    {
        Vector3 index = GetSquare(pos).GridIndex;
        List<GridSquare> neighbors = new List<GridSquare>();

        for(int i = -distance; i <= distance; i++){
            if (index.x + i >= 0 && index.x + i < GridX){
                for (int j = -distance; j <= distance; j++){
                    if (index.y + j >= 0 && index.y + j < GridY){
                        for (int k = -distance; k <= distance; k++){
                            if (index.z + k >= 0 && index.z + k < GridZ)
                            {
                                neighbors.Add(grid[i+(int)index.x, j+(int)index.y, k+(int)index.z]);
                            }
                        }
                    }
                }
            }
        }

        return neighbors;
        
    }

    public List<GridSquare> GetNeighborCorners(Vector3 pos, int distance = 1)
    {
        Vector3 index = GetCorner(pos).GridIndex;
        List<GridSquare> neighbors = new List<GridSquare>();

        for (int i = -distance; i <= distance; i++){
            if (index.x + i >= 0 && index.x + i < GridX){
                for (int j = -distance; j <= distance; j++){
                    if (index.y + j >= 0 && index.y + j < GridY){
                        for (int k = -distance; k <= distance; k++){
                            if (index.z + k >= 0 && index.z + k < GridZ){
                                neighbors.Add(corners[i + (int)index.x, j + (int)index.y, k + (int)index.z]);
                            }
                        }
                    }
                }
            }
        }

        return neighbors;
    }

    private void Start()
    {
        CreateGrid(); //TEMP
        //IDEA WILL BE TO LOAD GRID FROM A SAVED FILE
    }

    private void CreateGrid()
    {
        GridX = (int)transform.lossyScale.x | 0x1; // Force odd and ensure at least one
        GridY = (int)transform.lossyScale.y | 0x1;
        GridZ = (int)transform.lossyScale.z | 0x1;       
        grid = new GridSquare[GridX, GridY, GridZ];
        corners = new GridSquare[GridX - 1, GridY - 1, GridZ - 1]; // Ignoring outer corners
        
        for (int i = 0; i < GridX; i++){
            for(int j = 0; j < GridY; j++){
                for(int k = 0; k < GridZ; k++){
                    grid[i, j, k] = 
                        new GridSquare(transform.position + new Vector3(i-(GridX/2),j-(GridY/2),k-(GridZ/2)), new Vector3(i,j,k));

                    if(i > 0 && j > 0 && k > 0)
                    {
                        corners[i - 1, j - 1, k - 1] = 
                            new GridSquare(grid[i, j, k].Location - (Vector3.one * 0.5f), new Vector3(i - 1, j - 1, k - 1)); 
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 size = Vector3.one * 0.5f;

        if (grid != null)
        {
            foreach (GridSquare square in grid)
            {
                Gizmos.color = Color.blue;
                if (!square.active)
                    Gizmos.DrawCube(square.Location, size);

            }
        }

        if (corners != null)
        {
            foreach (GridSquare corner in corners)
            {
                Gizmos.color = Color.red;
                if (!corner.active)
                {
                    Gizmos.DrawSphere(corner.Location, 0.5f);
                }
            }
        }
    }
    
}
