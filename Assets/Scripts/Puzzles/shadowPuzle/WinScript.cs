using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject mySwords;
    
    void Start()
    {
        pointsToWin = mySwords.transform.childCount;
    }

    
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            // WIN
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
