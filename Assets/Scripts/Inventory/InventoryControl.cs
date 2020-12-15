using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject miniMapIcon;
    public GameObject inventoryIcon;
    public GameObject inventoryUI;
    public GameObject dialogManager;
    public GameObject mapLocations;
    public GameObject closeCross;

    InventoryUI inventory;
    Transform currentLoc;

    private void Awake()
    {
        inventory = inventoryUI.GetComponent<InventoryUI>();
    }

    private void Update()
    {
        if (!dialogManager.GetComponent<DialogueManager>().InConvo && !mapLocations.GetComponent<sceneManager>().getPuzleState())
        {
            miniMapIcon.SetActive(true);
            inventoryIcon.SetActive(true);
        }
        else
        {
            miniMapIcon.SetActive(false);
            inventoryIcon.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        inventory.changeInventoryState();

        if (inventory.animationActivated)
        {
            inventoryIcon.SetActive(false);
            for (int i = 0; i < mapLocations.transform.childCount; i++)
            {
                if (mapLocations.transform.GetChild(i).gameObject.activeSelf)
                {
                    currentLoc = mapLocations.transform.GetChild(i).transform;
                    currentLoc.Find("InteractiveBackground").gameObject.SetActive(false);
                    closeCross.GetComponent<InventoryControl>().currentLoc = currentLoc;
                }
            }
        }

        else
        {
            inventoryIcon.SetActive(true);
            currentLoc.Find("InteractiveBackground").gameObject.SetActive(true);
        }
    }
}
