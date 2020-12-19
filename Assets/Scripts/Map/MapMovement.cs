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
        if (manager.InConvo || mapLocations.GetComponent<sceneManager>().getPuzleState())
        {
            if(GetComponent<SpriteRenderer>() != null)
            {
                if (GetComponent<SpriteRenderer>().sprite.name == "Highlight_BusStop_Almacen" || GetComponent<SpriteRenderer>().sprite.name == "Highlight_BusStop_Cruce")
                    GetComponent<BoxCollider2D>().enabled = false;
                else
                    GetComponent<SpriteRenderer>().enabled = false;
            }
            GetComponent<CursorObject>().active= false;
            active = false;
        }
        else
        {
            if (GetComponent<SpriteRenderer>() != null)
            {
                if (GetComponent<SpriteRenderer>().sprite.name == "Highlight_BusStop_Almacen" || GetComponent<SpriteRenderer>().sprite.name == "Highlight_BusStop_Cruce")
                    GetComponent<BoxCollider2D>().enabled = true;
                else
                    GetComponent<SpriteRenderer>().enabled = true;
            }
                
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

            //Change puzle state
            if (nextLocation.GetComponent<ScenePuzle>() != null && !nextLocation.GetComponent<ScenePuzle>().doorState())
            {
                sceneManager.changePuzleState();
            }
            else if (sceneManager.getPuzleState())
            {
                sceneManager.changePuzleState();
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
