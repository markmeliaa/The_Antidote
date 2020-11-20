using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
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

        currentDialogScript = currentLocation.GetComponent<AutomaticDialogs>();
        nextDialogScript = nextLocation.GetComponent<AutomaticDialogs>();

        if (currentDialogScript != null)
            currentDialogScript.enabled = false;

        if(nextDialogScript != null)
        {
            nextDialogScript.enabled = true;
            nextDialogScript.activated = false;
        }
            

        nextLocation.SetActive(true);

        //Charge new Map
        miniMap.GetComponent<miniMap>().chargeMap();

        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }
}
