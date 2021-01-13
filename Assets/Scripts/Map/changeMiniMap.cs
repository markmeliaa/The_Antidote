using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMiniMap : MonoBehaviour
{
    private GameObject currentMap;
    private GameObject nextMap;
    bool changed = false;

    public sceneManager manager;
    public GameObject location;
    public int timesVisited;

    // Start is called before the first frame update
    void Start()
    {
        currentMap = transform.Find("EnterpriseMap").gameObject;
        nextMap = transform.Find("EnterpriseMap").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!changed && manager.getLocationTimes(location.name) == timesVisited)
        {
            currentMap.SetActive(false);
            nextMap.SetActive(true);
            changed = true;
        }
    }
}
