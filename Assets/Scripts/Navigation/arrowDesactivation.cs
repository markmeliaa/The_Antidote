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
            if(navigationItem[indexDesactivations].GetComponent<SpriteRenderer>() != null 
                && navigationItem[indexDesactivations].GetComponent<SpriteRenderer>().sprite.name == "Parada Bus")
            {
                navigationItem[indexDesactivations].GetComponent<BoxCollider2D>().enabled = false;
            }
            else
                navigationItem[indexDesactivations].SetActive(false);

            indexDesactivations++;
        }
    }
}
