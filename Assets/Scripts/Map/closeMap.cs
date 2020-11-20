using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeMap : MonoBehaviour
{
    public GameObject miniMap;

    private Map map;
    private miniMap miniMapScript;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("InteractiveMap").GetComponent<Map>();
        miniMapScript = miniMap.GetComponent<miniMap>();
    }

    private void OnMouseDown()
    {
        map.closeMap();
        miniMapScript.opened = false;
    }
}
