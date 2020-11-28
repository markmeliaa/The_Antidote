#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public GameObject mapLocations;
    public GameObject nextLocation;
    public GameObject currentLocation;
    public GameObject miniMap;

    [SerializeField] private GameObject dialogueManager;

    private AutomaticDialogs currentDialogScript = null;
    private AutomaticDialogs nextDialogScript = null;

    private void OnMouseDown()
    {
        //Reset dialogueManager
        dialogueManager.SetActive(false);
        dialogueManager.SetActive(true);

        //Reset location
        currentLocation.SetActive(false);

        //Change state of location
        if (!mapLocations.GetComponent<sceneManager>().getLocationBool(nextLocation.name))
            mapLocations.GetComponent<sceneManager>().setLocationBool(nextLocation.name);

        currentDialogScript = currentLocation.GetComponent<AutomaticDialogs>();
        nextDialogScript = nextLocation.GetComponent<AutomaticDialogs>();

        if (currentDialogScript != null)
            currentDialogScript.enabled = false;

        if(nextDialogScript != null)
            nextDialogScript.enabled = true;
            

        nextLocation.SetActive(true);

        //Charge new Map
        miniMap.GetComponent<miniMap>().chargeMap();

        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }
}
