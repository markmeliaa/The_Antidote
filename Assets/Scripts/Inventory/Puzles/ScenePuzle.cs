using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePuzle : MonoBehaviour
{
    public GameObject[] arrows;
    public DialogueManager manager;
    public Conversation warning;

    bool opened = false;

    private void Update()
    {
        if (!manager.InConvo)
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].GetComponent<SpriteRenderer>().enabled = true;
                arrows[i].GetComponent<CursorObject>().active = true;
                arrows[i].GetComponent<MapMovement>().active = true;
            }
        }
    }

    public void openTheDoor()
    {
        opened = true;
        GetComponentInParent<sceneManager>().changePuzleState();
    }

    public bool doorState()
    {
        return opened;
    }

    public void showWarning()
    {
        DialogueManager.StartConversation(warning);
    }
}
