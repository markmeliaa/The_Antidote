using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string description = "New description";

    [SerializeField]
    GameObject descriptionText;


    public virtual void showDescription()
    {
        descriptionText = GameObject.Find("description").gameObject;
        descriptionText.GetComponentInChildren<Text>().text = description;
    }

    public virtual void Use()
    {
        Debug.Log("Using on a Puzle");
    }
}
