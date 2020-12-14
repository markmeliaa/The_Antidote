using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzleManager : MonoBehaviour
{
    //Scene controller
    public desactivatePuzzle puzleEnding;

    //Puzle Stuff
    public GameObject PipesHolder;
    public GameObject[,] Pipes;
    public TextMesh endText;
    public int colSize;

    GameObject lastPipe;

    [SerializeField]
    int totalPipes = 0;
    
    //Keeping all the pipes
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;
        Pipes = new GameObject[totalPipes/colSize, colSize];

        int col = 0;
        int fil = 0;
        for (int i = 0; i < PipesHolder.transform.childCount; i++)
        {
            Pipes[fil, col] = PipesHolder.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject;

            if(Pipes[fil, col].GetComponent<PipeScript>().types == 1)
            {
                lastPipe = Pipes[fil, col];
            }

            col++;
            if (col >= colSize)
            {
                col = 0;
                fil++;
            }   
        }

        //Saving the neightbours of each pipe
        for (int i = 0; i < Pipes.GetLength(0); i++)
        {
            for (int j = 0; j < Pipes.GetLength(1); j++)
            {
                PipeScript currentPipe = Pipes[i, j].GetComponent<PipeScript>();

                currentPipe.myI = i;
                currentPipe.myJ = j;

                if (i != 0)
                    currentPipe.connectedPipes.Add(new PipeScript.Pair(i - 1, j));

                if (i != (Pipes.GetLength(0) - 1))
                    currentPipe.connectedPipes.Add(new PipeScript.Pair(i + 1, j));

                if (j != 0)
                    currentPipe.connectedPipes.Add(new PipeScript.Pair(i, j - 1));

                if (j != (Pipes.GetLength(1) - 1))
                    currentPipe.connectedPipes.Add(new PipeScript.Pair(i, j + 1));
            }
        }
    }

    //Checking the victory condition
    private void Update()
    {
        if (lastPipe.GetComponent<PipeScript>().connected)
        {

            for (int i = 0; i < Pipes.GetLength(0); i++)
            {
               for (int j = 0; j < Pipes.GetLength(1); j++)
               {
                    Pipes[i, j].GetComponent<PipeScript>().notRotable = true;
               }
            }
            endPuzle();
        }   
    }

    public void resetPuzle()
    {
        for (int i = 0; i < Pipes.GetLength(0); i++)
        {
            for (int j = 0; j < Pipes.GetLength(1); j++)
            {
                PipeScript currentPipe = Pipes[i, j].GetComponent<PipeScript>();

                currentPipe.resetPipes();
            }
        }
    }

    private void endPuzle()
    {
        endText.gameObject.SetActive(true);    
        puzleEnding.desactivate();
    }
}
