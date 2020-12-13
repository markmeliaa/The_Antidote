using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePuzle : MonoBehaviour
{
    public GameObject puzle;
    public GameObject background;
    public GameObject miniMap;
    public GameObject inventory;
    public TextMesh winText;
    public GameObject mapLoc;
    public DialogueManager manager;

    bool active;
    private void OnMouseDown()
    {
        if (active)
        {
            mapLoc.GetComponent<sceneManager>().changePuzleState();
            background.SetActive(false);
            puzle.SetActive(true);
            miniMap.SetActive(false);
            inventory.SetActive(false);
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

    IEnumerator waitWin()
    {
        yield return new WaitForSeconds(2);
        background.SetActive(true);
        puzle.SetActive(false);
        this.gameObject.SetActive(false);
        miniMap.SetActive(true);
        inventory.SetActive(true);
    }
}
