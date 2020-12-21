using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePuzle : MonoBehaviour
{
    public GameObject puzle;
    public GameObject background;
    public TextMesh winText;
    public GameObject mapLoc;
    public GameObject inventory;
    public DialogueManager manager;
    public Animator rectangleL;
    public Animator rectangleR;
    public float transitionTime = 0f;
    public Animator texts;

    bool active;

    private void OnMouseDown()
    {
        if (active)
        {
            rectangleL.SetBool("startPuzzle", true);
            rectangleR.SetBool("startPuzzle", true);
            texts.SetBool("startGame", true);
            StartCoroutine("waitPuzzle");
        }
    }

    private void Update()
    {
        if (winText.gameObject.activeSelf)
        {
            StartCoroutine("waitWin");
        }

        if (manager.InConvo)
        {
            GetComponent<CursorObject>().active = false;
            active = false;
        }
        else
        {
            GetComponent<CursorObject>().active = true;
            active = true;
        }
    }

    IEnumerator waitPuzzle()
    {
        yield return new WaitForSeconds(4);
        rectangleL.SetBool("startPuzzle", false);
        rectangleR.SetBool("startPuzzle", false);
        texts.SetBool("startGame", false);
        yield return new WaitForSeconds(transitionTime);
        mapLoc.GetComponent<sceneManager>().changePuzleState();
        background.SetActive(false);
        puzle.SetActive(true);
        inventory.GetComponent<InventoryControl>().normalPuzle = true;
        inventory.SetActive(false);
        yield return new WaitForSeconds(2);
    }

    IEnumerator waitWin()
    {
        yield return new WaitForSeconds(2);
        background.SetActive(true);
        puzle.SetActive(false);
        this.gameObject.SetActive(false);
        inventory.SetActive(true);
        inventory.GetComponent<InventoryControl>().normalPuzle = false;
    }
}
