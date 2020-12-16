using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDesactivation : MonoBehaviour
{
    public GameObject[] navigationItem;
    public int[] timesVisitedDesactivations;


    sceneManager manager;
    int indexDesactivations;

    private void Start()
    {
        manager = GetComponentInParent<sceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkDesactivation();
    }

    void checkDesactivation()
    {
        if (indexDesactivations < timesVisitedDesactivations.Length && manager.getLocationTimes(gameObject.name) == timesVisitedDesactivations[indexDesactivations])
        {
            navigationItem[indexDesactivations].SetActive(false);
            indexDesactivations++;
        }
    }
}
