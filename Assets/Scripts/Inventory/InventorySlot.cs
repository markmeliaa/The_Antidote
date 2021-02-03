using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public GameObject mapLoc;
    public InventoryControl inventoryControl;

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
            if (!mapLoc.GetComponent<sceneManager>().getPuzleState())
                item.showDescription();
            else
            {
                for (int i = 0; i < mapLoc.transform.childCount; i++)
                {
                    if (mapLoc.transform.GetChild(i).gameObject.activeSelf && mapLoc.transform.GetChild(i).name == item.puzleAim)
                    {
                        item.Use(mapLoc.transform.GetChild(i).gameObject);

                        if (item.eliminate)
                            RemoveItem();

                        inventoryControl.activateInventoryChanging();
                    }
                }
            }
        }
    }
}
