using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int pointsToWin;
    public int currentPoints;
    public GameObject myPlanets;
    public sceneManager manager;
    void Start()
    {
        pointsToWin = myPlanets.transform.childCount;
    }

    
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            manager.changePuzleState();
            // WIN
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
