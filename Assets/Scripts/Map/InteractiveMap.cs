#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMap : MonoBehaviour
{
    public miniMap miniMap;

    [SerializeField] private GameObject nextLocation;
    public int locations;

    private void OnMouseDown()
    {
        for (int i = 0; i < locations; i++)
        {
            // Desactivamos la ubicación actual pero activamos el interactive background en el que estamos
            GameObject actualLocation = GameObject.Find("Map Locations").transform.GetChild(i).gameObject;
            Map mapScript = GameObject.Find("InteractiveMap").GetComponent<Map>();
            for (int j = 0; j < actualLocation.transform.childCount; j++)
            {
                actualLocation.transform.GetChild(j).gameObject.SetActive(true);
                miniMap.opened = false;
            }

            actualLocation.SetActive(false);

            // Activamos la ubicación a la que queremos viajar
            mapScript.dialogueCanvas.SetActive(true);
            nextLocation.SetActive(true);

            //Charge mini Map
            miniMap.GetComponent<miniMap>().chargeMap();
        }
    }
}
