#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [System.Serializable]
    public class Cell
    {
        public bool visited;
        public GameObject north; // 1
        public GameObject west; // 2
        public GameObject east; // 3
        public GameObject south; // 4
    }

    public GameObject wall;
    public float wallLength = 1.0f;
    public int xSize = 5; // Rows X Axis
    public int ySize = 5; // Rows Y Axis
    private Vector3 initialPos;
    private GameObject wallHolder;

    private Cell[] cells;

    private int currentCell;
    private int totalCells;

    private int visitedCells = 0;
    private bool startedBuilding = false;
    private int currentNeighbour;
    private List<int> lastCells;
    private int backingUp = 0;

    private int wallToBreak = 0;

    [SerializeField] GameObject gameArea;

    // Start is called before the first frame update
    void Start()
    {
        CreateWalls();
    }

    void CreateWalls()
    {
        wallHolder = new GameObject();
        wallHolder.name = "Maze";
        wallHolder.transform.SetParent(gameArea.transform);

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
        lastCells = new List<int>();
        lastCells.Clear();
        totalCells = xSize * ySize;
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
            if (termCount == xSize)
            {
                eastWestProcess++;
                termCount = 0;
            }

            cells[cellprocess] = new Cell();
            cells[cellprocess].west = allWalls[eastWestProcess];
            cells[cellprocess].south = allWalls[childProcess + (xSize + 1) * ySize];

           eastWestProcess++;

            termCount++;
            childProcess++;

            cells[cellprocess].east = allWalls[eastWestProcess];
            cells[cellprocess].north = allWalls[(childProcess + (xSize + 1) * ySize) + xSize - 1];
        }

        CreateMaze();
    }

    void CreateMaze()
    {
        while(visitedCells < totalCells)
        {
            if (startedBuilding)
            {
                GiveMeNeighbour();
                if(cells[currentNeighbour].visited == false && cells[currentCell].visited == true)
                {
                    BreakWall();
                    cells[currentNeighbour].visited = true;
                    visitedCells++;
                    lastCells.Add(currentCell);
                    currentCell = currentNeighbour;

                    if(lastCells.Count > 0)
                    {
                        backingUp = lastCells.Count - 1;
                    }
                }
            }

            else
            {
                currentCell = Random.Range(0, totalCells);
                cells[currentCell].visited = true;
                visitedCells++;
                startedBuilding = true;
            }
        }
    }

    void BreakWall()
    {
        switch (wallToBreak)
        {
            case 1: Destroy(cells[currentCell].north); break;
            case 2: Destroy(cells[currentCell].west); break;
            case 3: Destroy(cells[currentCell].east); break;
            case 4: Destroy(cells[currentCell].south); break;
        }
    }

    void GiveMeNeighbour()
    {
        int length = 0;
        int[] neighbours = new int[4];
        int[] connectingWall = new int[4];
        int checkCorner;

        checkCorner = ((currentCell + 1) / xSize);
        checkCorner -= 1;
        checkCorner *= xSize;
        checkCorner += xSize;

        // Exists east cell
        if(currentCell + 1 < totalCells && (currentCell + 1) != checkCorner)
        {
            if(cells[currentCell + 1].visited == false)
            {
                neighbours[length] = currentCell + 1;
                connectingWall[length] = 3;
                length++;
            }
        }

        // Exists west cell
        if (currentCell - 1 >= 0 && currentCell != checkCorner)
        {
            if (cells[currentCell - 1].visited == false)
            {
                neighbours[length] = currentCell - 1;
                connectingWall[length] = 2;
                length++;
            }
        }

        // Exists north cell
        if (currentCell + xSize < totalCells)
        {
            if (cells[currentCell + xSize].visited == false)
            {
                neighbours[length] = currentCell + xSize;
                connectingWall[length] = 1;
                length++;
            }
        }

        // Exists south cell
        if (currentCell - xSize >= 0)
        {
            if (cells[currentCell - xSize].visited == false)
            {
                neighbours[length] = currentCell - xSize;
                connectingWall[length] = 4;
                length++;
            }
        }

        if(length != 0)
        {
            int theChosenOne = Random.Range(0, length);
            currentNeighbour = neighbours[theChosenOne];
            wallToBreak = connectingWall[theChosenOne];
        }

        else
        {
            if(backingUp > 0)
            {
                currentCell = lastCells[backingUp];
                backingUp--;
            }
        }
    }

    public void resetValues(GameObject gameArea)
    {
        GameObject maze = gameArea.transform.Find("Maze").gameObject;


        for (int i = 0; i < maze.transform.childCount; i++)
        {
            Destroy(maze.transform.GetChild(i).gameObject);
        }

        Destroy(maze);

        cells = new Cell[0];
        currentCell = 0;
        totalCells = 0;
        visitedCells = 0;
        startedBuilding = false;
        currentNeighbour = 0;
        lastCells.Clear();
        backingUp = 0;
        wallToBreak = 0;
        CreateWalls();
    }
}
