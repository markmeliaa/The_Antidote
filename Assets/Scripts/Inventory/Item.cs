using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Text descriptionText;
    new public string name = "New Item";
    public Sprite icon = null;
    public string description = "New description";

    public virtual void Use()
    {
        descriptionText.text = description;
        Debug.Log("Using " + name);
    }
}
