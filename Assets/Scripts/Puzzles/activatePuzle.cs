using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePuzle : MonoBehaviour
{
    public GameObject puzle;
    public GameObject background;
    public TextMesh winText;

    private void OnMouseDown()
    {
        background.SetActive(false);
        puzle.SetActive(true);
    }

    private void Update()
    {
        if (winText.gameObject.activeSelf)
        {
            StartCoroutine("waitWin");
        }
    }

    IEnumerator waitWin()
    {
        yield return new WaitForSeconds(2);
        background.SetActive(true);
        puzle.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
