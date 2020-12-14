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
    public TextMeshProUGUI thanksText;

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
        yield return new WaitForSeconds(2);
        thanksText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        currentPuzzle.SetActive(false);
        background.SetActive(true);
        inventory.SetActive(true);
        mapLoc.GetComponent<sceneManager>().changePuzleState();
        rectangleL.SetBool("startPuzzle", false);
        rectangleR.SetBool("startPuzzle", false);
        thanksText.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
    }
}
