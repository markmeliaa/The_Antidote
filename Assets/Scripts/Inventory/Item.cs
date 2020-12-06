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
    public GameObject spawnObject;
    public string puzleAim;

    GameObject descriptionText;


    public virtual void showDescription()
    {
        descriptionText = GameObject.Find("description").gameObject;
        descriptionText.GetComponentInChildren<Text>().text = description;
    }

    public virtual void Use(GameObject location)
    {
        GameObject newObject = Instantiate(spawnObject, new Vector3(0, -3, 0), Quaternion.identity);
        newObject.GetComponent<MoveItems>().puzleLocation = location;
    }
}
