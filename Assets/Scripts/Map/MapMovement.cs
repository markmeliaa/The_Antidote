using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public GameObject nextLocation;
    public GameObject currentLocation;
    [SerializeField] private GameObject dialogueManager;

    private void OnMouseDown()
    {
        //Reset dialogueManager
        dialogueManager.SetActive(false);
        dialogueManager.SetActive(true);

        //Reset location
        currentLocation.SetActive(false);
        nextLocation.SetActive(true);
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }
}
