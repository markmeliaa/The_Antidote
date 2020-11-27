using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryIcon;
    public GameObject inventoryUI;

    InventoryUI inventory;

    private void Awake()
    {
        inventory = inventoryUI.GetComponent<InventoryUI>();
    }

    private void OnMouseDown()
    {
        inventory.changeInventoryState();

        if (inventory.animationActivated)
        {
            inventoryIcon.SetActive(false);
        }
        else
        {
            inventoryIcon.SetActive(true);
        }
        
    }
}
