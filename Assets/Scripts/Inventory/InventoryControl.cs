using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryIcon;
    public GameObject inventoryUI;
    public GameObject dialogManager;

    InventoryUI inventory;

    private void Awake()
    {
        inventory = inventoryUI.GetComponent<InventoryUI>();
    }

    private void OnMouseDown()
    {
        if (!dialogManager.GetComponent<DialogueManager>().InConvo)
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
}
