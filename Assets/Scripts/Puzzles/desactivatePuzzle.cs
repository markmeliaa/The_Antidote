using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject currentPuzzle;
    [SerializeField] GameObject background;
    public GameObject mapLoc;
    public GameObject miniMap;
    public GameObject inventory;

    private void OnMouseDown()
    {
        desactivate();
    }

    public void desactivate()
    {
        currentPuzzle.SetActive(false);
        background.SetActive(true);
        miniMap.SetActive(true);
        inventory.SetActive(true);
        mapLoc.GetComponent<sceneManager>().changePuzleState();
    }
}
