using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowActivation : MonoBehaviour
{
    public GameObject[] navigationItem;
    public int[] timesVisitedActivations;


    sceneManager manager;
    int indexActivations;

    private void Start()
    {
        manager = GetComponentInParent<sceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkActivation();
    }

    void checkActivation()
    {
        if (indexActivations < timesVisitedActivations.Length && manager.getLocationTimes(gameObject.name) == timesVisitedActivations[indexActivations])
        {
            navigationItem[indexActivations].SetActive(true);
            indexActivations++;
        }
    }
}
