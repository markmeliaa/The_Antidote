using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzleManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[,] Pipes;
    public Text endText;
    public int rowSize;

    GameObject lastPipe;

    [SerializeField]
    int totalPipes = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;
        Pipes = new GameObject[totalPipes/rowSize, rowSize];

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
            if (col >= 5)
            {
                col = 0;
                fil++;
            }   
        }

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

    private void Update()
    {
        if (lastPipe.GetComponent<PipeScript>().connected)
            endPuzle();
    }

    private void endPuzle()
    {
        endText.gameObject.SetActive(true);
        for (int i = 0; i < Pipes.GetLength(0); i++)
        {
            for (int j = 0; j < Pipes.GetLength(1); j++)
            {
                Pipes[i, j].GetComponent<PipeScript>().notRotable = true;
            }
        }
    }
}
