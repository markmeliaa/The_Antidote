using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public bool sceneWithPuzle = false;
    private bool optional;
   public void Interact(bool compulsoryPuzle)
    {
        optional = compulsoryPuzle;
        PickUp();
    }

    void PickUp()
    {
        bool wasPickUp = Inventory.instance.Add(item);
        if (wasPickUp)
        {
            if(!optional)
                Destroy(gameObject);

            CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
        }
    }      
}
