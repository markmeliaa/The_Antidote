using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePipePuzle : MonoBehaviour
{
    public GameObject puzleObject;
    public GameObject interactiveBackground;
    public GameObject miniMap;
    public bool puzleDone = false;
    public DialogueManager manager;

    bool active;

    private void Start()
    {
        manager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
    }
    private void Update()
    {
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

    private void OnMouseDown()
    {
        if (active)
        {
            miniMap.SetActive(false);
            interactiveBackground.SetActive(false);
            puzleObject.SetActive(true);
            transform.GetComponent<CursorObject>().gameObject.SetActive(false);
        }
    }
}
