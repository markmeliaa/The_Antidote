using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [System.Serializable]
    public class Cell
    {
        public bool visited;
        public GameObject north;
        public GameObject east;
        public GameObject west;
        public GameObject south;
    }

    public GameObject wall;
    public float wallLength = 1.0f;
    public int xSize = 5; // Rows X Axis
    public int ySize = 5; // Rows Y Axis
    private Vector3 initialPos;
    private GameObject wallHolder;

    private Cell[] cells;

    // Start is called before the first frame update
    void Start()
    {
        CreateWalls();
    }

    void CreateWalls()
    {
        wallHolder = new GameObject();
        wallHolder.name = "Maze";

        initialPos = new Vector3((-xSize/2) + wallLength/2, (-ySize/2) + wallLength/2, 0.0f);
        Vector3 myPos = initialPos;
        GameObject tempWall;

        // For X Axis
        for(int i = 0; i < ySize; i++)
        {
            for(int j = 0; j <= xSize; j++)
            {
                myPos = new Vector3(initialPos.x + (j * wallLength) - wallLength / 2, initialPos.y + (i * wallLength) - wallLength / 2, 0.0f);
                tempWall = Instantiate(wall, myPos, Quaternion.identity) as GameObject;
                tempWall.name = "Wall " + i + "." + j + " (V)";
                tempWall.transform.parent = wallHolder.transform;
            }
        }

        // For Y Axis
        for (int i = 0; i <= ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                myPos = new Vector3(initialPos.x + (j * wallLength), initialPos.y + (i * wallLength) - wallLength, 0.0f);
                tempWall = Instantiate(wall, myPos, Quaternion.Euler(0.0f, 0.0f, 90.0f)) as GameObject;
                tempWall.name = "Wall " + i + "." + j + " (H)";
                tempWall.transform.parent = wallHolder.transform;
            }
        }

        CreateCells();
    }

    void CreateCells()
    {
        int children = wallHolder.transform.childCount;
        GameObject[] allWalls = new GameObject[children];
        cells = new Cell[xSize * ySize];
        int eastWestProcess = 0;
        int childProcess = 0;
        int termCount = 0;

        // Gets all the children
        for (int i = 0; i < children; i++)
        {
            allWalls[i] = wallHolder.transform.GetChild(i).gameObject;
        }

        // Assigns walls to the cells
        for (int cellprocess = 0; cellprocess < cells.Length; cellprocess++)
        {
            cells[cellprocess] = new Cell();
            cells[cellprocess].west = allWalls[eastWestProcess];
            cells[cellprocess].south = allWalls[childProcess + (xSize + 1) * ySize];

            if (termCount == xSize)
            {
                eastWestProcess += 2;
                termCount = 0;
            }

            else
                eastWestProcess++;

            termCount++;
            childProcess++;

            cells[cellprocess].east = allWalls[eastWestProcess];
            cells[cellprocess].north = allWalls[(childProcess + (xSize + 1) * ySize) + xSize - 1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
