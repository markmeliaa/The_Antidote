using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[][] Pipes;

    [SerializeField]
    int totalPipes = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;
        Pipes = new GameObject[totalPipes/5][];
        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = new GameObject[5];
        }

        for (int i = 0; i < Pipes.Length; i++)
        {
            for(int j = 0; j < Pipes[0].Length; j++)
            {
                Pipes[i][j] = PipesHolder.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject;

                //Pipes[i][j].GetComponent<PipeScript>().connectedPipes.Add();
            }
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
