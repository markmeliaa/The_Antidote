using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public bool inAPuzle = false;
    public GameObject mapLoc;

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
                for (int i = 0; i < mapLoc.transform.childCount; i++)
                {
                    if (mapLoc.transform.GetChild(i).name == item.puzleAim.name)
                    {
                        item.Use();
                        RemoveItem();
                    }
                }
            }
        }
    }
}
