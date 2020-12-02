#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    public bool active = true;
    ItemPickUp pickUpItems;
    private void Awake()
    {
        pickUpItems = GetComponentInParent<ItemPickUp>();
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

        if(pickUpItems != null)
        {
            pickUpItems.Interact();
        } 
    }
}
