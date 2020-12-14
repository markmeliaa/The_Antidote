using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class desactivatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject currentPuzzle;
    [SerializeField] GameObject background;
    public GameObject mapLoc;
    public GameObject inventory;
    public Animator rectangleL;
    public Animator rectangleR;
    public Animator text;

    private void OnMouseDown()
    {
        desactivate();
    }

    public void desactivate()
    {
        StartCoroutine("desactivatethis");
    }

    IEnumerator desactivatethis()
    {
        rectangleL.SetBool("startPuzzle", true);
        rectangleR.SetBool("startPuzzle", true);
        text.SetBool("endGame", true);
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(1);
        currentPuzzle.SetActive(false);
        background.SetActive(true);
        inventory.SetActive(true);
        Debug.Log(1);
        mapLoc.GetComponent<sceneManager>().changePuzleState();
        text.SetBool("endGame", false);
        rectangleL.SetBool("startPuzzle", false);
        rectangleR.SetBool("startPuzzle", false);
    }
}
