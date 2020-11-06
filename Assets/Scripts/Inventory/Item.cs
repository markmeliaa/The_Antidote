using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string description = "New description";

    public virtual void Use()
    {
        //Aqui metemos que pase algo si pulsa en el inventario sobre un item

        Debug.Log("Using " + name);
    }
}
