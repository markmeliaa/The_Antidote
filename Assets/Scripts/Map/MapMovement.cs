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
    public bool active;
    public bool objectPuzleInactivate = false;

    [SerializeField] private GameObject dialogueManager;

    private AutomaticDialogs currentDialogScript = null;
    private AutomaticDialogs nextDialogScript = null;
    private DialogueManager manager;
    
    private sceneManager sceneManager;

    private void Start()
    {
        manager = dialogueManager.transform.Find("DialogueBox1").GetComponent<DialogueManager>();
        sceneManager = GameObject.Find("Map Locations").GetComponent<sceneManager>();
    }

    private void Update()
    {
        if (manager.InConvo || (sceneManager.getPuzleState() && !sceneManager.getObjectPuzleState()))
        {
            if (GetComponent<BoxCollider2D>() != null)
                GetComponent<BoxCollider2D>().enabled = false;

            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().enabled = false;

            GetComponent<CursorObject>().active = false;
            active = false;
        }
        else if (!objectPuzleInactivate)
        {
            if (GetComponent<BoxCollider2D>() != null)
                GetComponent<BoxCollider2D>().enabled = true;

            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().enabled = true;

            GetComponent<CursorObject>().active = true;
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
            currentLocation.transform.GetChild(0).gameObject.SetActive(true);
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

            //Change puzle state
            if (nextLocation.GetComponent<ScenePuzle>() != null && !nextLocation.GetComponent<ScenePuzle>().doorState())
            {
                sceneManager.changePuzleState();
                sceneManager.changeObjectPuzleState();
            }
            else if (sceneManager.getPuzleState())
            {
                sceneManager.changePuzleState();
                sceneManager.changeObjectPuzleState();
            }

            nextLocation.SetActive(true);

            //Charge new Map
            miniMap.GetComponent<miniMap>().chargeMap();

            CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
        }
        else if (currentLocation.GetComponent<ScenePuzle>() != null)
        {
            currentLocation.GetComponent<ScenePuzle>().showWarning();
        }
    }
}
