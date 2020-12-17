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
            if (navigationItem[indexActivations].GetComponent<SpriteRenderer>() != null
                && navigationItem[indexActivations].GetComponent<SpriteRenderer>().sprite.name == "Parada Bus")
            {
                navigationItem[indexActivations].GetComponent<BoxCollider2D>().enabled = true;
            }
            else
                navigationItem[indexActivations].SetActive(true);
            indexActivations++;
        }
    }
}
