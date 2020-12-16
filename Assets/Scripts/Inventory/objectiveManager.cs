using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveManager : MonoBehaviour
{
    public string[] objectives;
    public GameObject[] locations;
    public int[] timesVisited;
    public sceneManager manager;

    int index = 0;

    void Update()
    {
        if(index < objectives.Length && manager.getLocationBool(locations[index].name) 
            && manager.getLocationTimes(locations[index].name) == timesVisited[index])
        {
            transform.GetChild(0).GetComponent<Text>().text = objectives[index];
            index++;
        }
    }
}
