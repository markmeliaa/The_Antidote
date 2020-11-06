using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
   public void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        bool wasPickUp = Inventory.instance.Add(item);
        if(wasPickUp)
            Destroy(gameObject);
    }
}
