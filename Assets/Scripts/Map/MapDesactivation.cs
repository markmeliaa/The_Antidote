using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDesactivation : MonoBehaviour
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
        if (index < timesVisited.Length && manager.getLocationTimes(conditions[index].name) == timesVisited[index])
        {
            checkDesactivation();
        }
    }

    private void checkDesactivation()
    {
        ubications[index].GetComponent<CircleCollider2D>().enabled = false;
        ubications[index].GetComponent<CursorObject>().active = false;
        index++;
    }
}
