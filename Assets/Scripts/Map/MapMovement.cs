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
    private DialogueManager manager;
    private bool active;

    private void Start()
    {
        manager = dialogueManager.transform.Find("DialogueBox").GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (manager.InConvo)
        {
            if(GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CursorObject>().active= false;
            active = false;
        }
        else
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<CursorObject>().active= true;
            active = true;
        }
    }

    private void OnMouseDown()
    {
        if (active)
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

            if (nextDialogScript != null)
                nextDialogScript.enabled = true;


            nextLocation.SetActive(true);

            //Charge new Map
            miniMap.GetComponent<miniMap>().chargeMap();

            CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
        }
    }
}
