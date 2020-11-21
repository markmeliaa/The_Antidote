using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePipePuzle : MonoBehaviour
{
    public GameObject puzleObject;
    public GameObject interactiveBackground;
    public GameObject miniMap;
    public bool puzleDone = false;

    private void OnMouseDown()
    {
        miniMap.SetActive(false);
        interactiveBackground.SetActive(false);
        puzleObject.SetActive(true);
        transform.GetComponent<CursorObject>().gameObject.SetActive(false);
    }
}
