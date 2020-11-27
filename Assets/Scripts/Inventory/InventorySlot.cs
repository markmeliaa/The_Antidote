using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public bool inAPuzle = false;

    Item item;
    

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void RemoveItem()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if (!inAPuzle)
                item.showDescription();
            else
            {
                item.Use();

                //Si es el que necesitamos
                //RemoveItem();
                //Sino
                //Texto aviso
            }   
        }
    }
}
