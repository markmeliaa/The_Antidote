using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour
{
    public GameObject mapLocations;
    public GameObject dialogManager;
    public bool opened;

    Map map;
    

    private void Start()
    {
        chargeMap();
    }

    public void chargeMap()
    {
        for (int i = 0; i < mapLocations.transform.childCount; i++)
        {
            if (mapLocations.transform.GetChild(i).gameObject.activeSelf)
            {
                GameObject activeLoc = mapLocations.transform.GetChild(i).gameObject;
                map = activeLoc.transform.GetChild(activeLoc.transform.childCount - 1).GetComponent<Map>();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!opened)
        {
            map.openMap();
            opened = true;
        }
        else
        {
            map.closeMap();
            opened = false;
        }
    }
}
