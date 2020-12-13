using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrySlide : MonoBehaviour
{
    public GameObject currentPuzle;

    private void OnMouseDown()
    {
        if (!currentPuzle.transform.Find("Text").GetChild(0).gameObject.activeSelf)
        {
            Transform objects = currentPuzle.transform.Find("GameArea").Find("Objects");
            for (int i = 0; i < objects.childCount; i++)
            {
                objects.GetChild(i).GetComponent<ObjectMovement>().resetObjects();
            }
        }
    }
}
