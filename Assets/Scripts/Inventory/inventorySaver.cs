using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class inventorySaver
{
    public static List<Item> savedItems = new List<Item>();

    public static List<Item> itemLoader()
    {
        return savedItems;
    }

    public static void itemSaver(List<Item> levelItems)
    {
        savedItems.Clear();

        for (int i = 0; i < levelItems.Count; i++)
        {
            savedItems.Add(levelItems[i]);
        }
    }
}
