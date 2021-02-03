using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    public void Awake()
    {
        if( instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        } 
        instance = this;
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallBack;
    public Item alternativeItem;

    public int space =  16;
    public List<Item> items = new List<Item>();

    public void setUpInventory()
    {
        List<Item> savedItems = inventorySaver.itemLoader();

        for (int i = 0; i < savedItems.Count; i++)
        {
            if (alternativeItem != null && savedItems[i].name == "Llaves")
                Add(alternativeItem);
            else
                Add(savedItems[i]);
        }
    }

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Mensaje alerta espacio");
            return false;
        }
        items.Add(item);

        Debug.Log("CallBack: "+ onItemChangedCallBack);
        if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
