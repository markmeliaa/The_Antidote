using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgoundChange : MonoBehaviour
{
    public Sprite[] newBackground;
    public GameObject miniMap;
    public GameObject[] changeConditions;
    public int[] changeTimes;
    int index = 0;
    sceneManager manager;

    private void Start()
    {
        manager = GetComponentInParent<sceneManager>();
    }

    private void Update()
    {
        if (index < changeConditions.Length && manager.getLocationBool(changeConditions[index].name)
            && manager.getLocationTimes(changeConditions[index].name) == changeTimes[index])
        {
            miniMap.SetActive(true);
            transform.Find("InteractiveBackground").GetComponent<SpriteRenderer>().sprite = newBackground[index];
            transform.Find("BackgroundMapGrey").GetComponent<SpriteRenderer>().sprite = newBackground[index];
            index++;
        }
    }
}
