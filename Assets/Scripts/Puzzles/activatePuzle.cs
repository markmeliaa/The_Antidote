using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePuzle : MonoBehaviour
{
    public GameObject puzle;
    public GameObject background;
    public TextMesh winText;
    public GameObject mapLoc;
    public DialogueManager manager;

    private void OnMouseDown()
    {
        if (!manager.InConvo)
        {
            mapLoc.GetComponent<sceneManager>().changePuzleState();
            background.SetActive(false);
            puzle.SetActive(true);
        }
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
