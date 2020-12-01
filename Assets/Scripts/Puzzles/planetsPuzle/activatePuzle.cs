using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePuzle : MonoBehaviour
{
    public GameObject puzle;
    public GameObject background;

    private void OnMouseDown()
    {
        background.SetActive(false);
        puzle.SetActive(true);
    }

    private void Update()
    {
        if (puzle.gameObject.activeSelf && GameObject.Find("PuzzleHandler").GetComponent<WinScript>().currentPoints >= GameObject.Find("PuzzleHandler").GetComponent<WinScript>().pointsToWin)
        {
            StartCoroutine("waitWin");
        }
    }

    IEnumerator waitWin()
    {
        yield return new WaitForSeconds(1);
        background.SetActive(true);
        puzle.SetActive(false);
    }
}
