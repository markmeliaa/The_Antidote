#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    ItemPickUp pickUpItems;
    private void Awake()
    {
        pickUpItems = GetComponentInParent<ItemPickUp>();
    }

    [SerializeField] private CursorManager.CursorType cursorType;
    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }

    private void OnMouseDown()
    {
        pickUpItems.Interact();
        // Hacer cosas al clickar
    }
}
