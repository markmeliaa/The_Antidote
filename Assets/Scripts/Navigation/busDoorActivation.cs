using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busDoorActivation : MonoBehaviour
{
    public GameObject nextBusDoor;
    public GameObject currentBusDoor;
    public GameObject altBusDoor;

    private bool active = true;
    private void Update()
    {
        if (altBusDoor.activeSelf)
            active = false;
    }

    private void OnMouseDown()
    {
        if (active)
        {
            currentBusDoor.SetActive(false);
            nextBusDoor.SetActive(true);
        }
    }
}
