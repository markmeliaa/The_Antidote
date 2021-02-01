using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int pointsToWin;
    public int currentPoints;
    public GameObject myPlanets;
    public desactivatePuzzle endPuzle;
    public bool compulsory = false;

    void Start()
    {
        pointsToWin = myPlanets.transform.childCount;
    }

    
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            if (compulsory)
                endPuzle.desactivate(true);
            else
                endPuzle.desactivate(false);

            // WIN
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
