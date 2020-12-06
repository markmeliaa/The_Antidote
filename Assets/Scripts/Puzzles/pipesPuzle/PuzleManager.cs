using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzleManager : MonoBehaviour
{
    //Scene controller
    public GameObject location;
    public GameObject miniMap;
    public GameObject mapLoc;

    //Puzle Stuff
    public GameObject PipesHolder;
    public GameObject[,] Pipes;
    public Text endText;
    public int rowSize;

    GameObject lastPipe;

    [SerializeField]
    int totalPipes = 0;
    float timer = 0.0f;
    float time = 5.0f;
    bool endShowing = false;
    
    //Keeping all the pipes
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
            if(timer == 0.0f)
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

            endPuzle();
        }   
    }

    private void endPuzle()
    {
        if (timer >= time)
            endShowing = true;

        if (endShowing)
        {
            endText.gameObject.SetActive(false);

            location.transform.Find("Puzle").gameObject.SetActive(false);
            location.transform.Find("InteractiveBackground").gameObject.SetActive(true);
            
            miniMap.SetActive(true);
            mapLoc.GetComponent<sceneManager>().setLocationTimes(location.name);
            mapLoc.GetComponent<sceneManager>().changePuzleState();
            location.GetComponent<Tester>().sceneWithInteraction = false;
            
        }
        else
            timer += Time.deltaTime;
        
    }
}
