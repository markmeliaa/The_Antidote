using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActivation : MonoBehaviour
{
    public GameObject[] ubications;
    public GameObject[] conditions;
    public int[] timesVisited;


    sceneManager manager;
    int index;

    private void Start()
    {
        manager = GetComponentInParent<sceneManager>();
    }
    private void Update()
    {
        if ( index < timesVisited.Length && manager.getLocationTimes(conditions[index].name) == timesVisited[index])
        {
            checkActivation();
        }

        if (index + 1 < timesVisited.Length && manager.getLocationTimes(conditions[index].name) > timesVisited[index])
            index++;
    }

    private void checkActivation()
    {
        ubications[index].GetComponent<CircleCollider2D>().enabled = true;
        ubications[index].GetComponent<CursorObject>().active = true;
        index++;
    }
}
