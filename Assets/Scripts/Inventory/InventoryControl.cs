using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryIcon;
    public GameObject inventoryUI;

    InventoryUI inventory;
    bool opened = false;

    private void Awake()
    {
        inventory = inventoryUI.GetComponent<InventoryUI>();
    }

    private void OnMouseDown()
    {
        inventory.changeInventoryState();
        if (!opened)
        {
            inventoryIcon.SetActive(false);
            opened = true;
        }
        else
        {
            inventoryIcon.SetActive(true);
            opened = false;
        }
        
    }
}
