using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject currentPuzzle;
    [SerializeField] GameObject background;
    public GameObject mapLoc;
    public GameObject miniMap;

    private void OnMouseDown()
    {
        desactivate();
    }

    public void desactivate()
    {
        currentPuzzle.SetActive(false);
        background.SetActive(true);
        miniMap.SetActive(true);
        mapLoc.GetComponent<sceneManager>().changePuzleState();
    }
}
