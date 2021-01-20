#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    public bool active = true;
    ItemPickUp pickUpItems;
    DialogueManager manager;
    sceneManager sceneManager;
    private void Awake()
    {
        pickUpItems = GetComponentInParent<ItemPickUp>();
        manager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
        sceneManager = GameObject.Find("Map Locations").GetComponent<sceneManager>();
    }

    [SerializeField] private CursorManager.CursorType cursorType;
    private void OnMouseEnter()
    {
        if(active)
            CursorManager.Instance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }

    private void OnMouseDown()
    {
        if (pickUpItems != null && pickUpItems.sceneWithPuzle)
        {
            if (!manager.InConvo)
            {
                pickUpItems.Interact();
            }
        }
        else
        {
            if (!manager.InConvo && !sceneManager.getPuzleState() && pickUpItems != null)
            {
                pickUpItems.Interact();
            }
        }
    }
}
