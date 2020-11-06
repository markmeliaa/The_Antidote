using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
   public void Interact()
    {
        Debug.Log("Interacting with item");

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickUp = Inventory.instance.Add(item);
        if(wasPickUp)
            Destroy(gameObject);
    }
}
