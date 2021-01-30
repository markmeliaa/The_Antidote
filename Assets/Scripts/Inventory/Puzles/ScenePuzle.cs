using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePuzle : MonoBehaviour
{
    public GameObject[] activeArrows;
    public GameObject[] inactiveArrows;
    public DialogueManager manager;
    public Conversation warning;
    public bool thereIsConver = false;

    bool opened = false;

    private void Update()
    {
        if (!opened)
        {
            for (int i = 0; i < activeArrows.Length; i++)
            {
                activeArrows[i].GetComponent<MapMovement>().active = true;
                if (activeArrows[i].GetComponent<SpriteRenderer>() != null)
                    activeArrows[i].GetComponent<SpriteRenderer>().enabled = true;
            }

            for (int i = 0; i < inactiveArrows.Length; i++)
            {
                inactiveArrows[i].GetComponent<MapMovement>().objectPuzleInactivate = true;
                inactiveArrows[i].GetComponent<MapMovement>().active = false;
                inactiveArrows[i].GetComponent<CursorObject>().active = false;
                if (inactiveArrows[i].GetComponent<SpriteRenderer>() != null)
                    inactiveArrows[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void openTheDoor()
    {
        opened = true;
        GetComponentInParent<sceneManager>().changePuzleState();
        GetComponentInParent<sceneManager>().changeObjectPuzleState();
        for (int i = 0; i < inactiveArrows.Length; i++)
            inactiveArrows[i].GetComponent<MapMovement>().objectPuzleInactivate = false;

        if (thereIsConver)
        {
            GetComponentInParent<sceneManager>().setLocationTimes(gameObject.name);
            GetComponent<Tester>().sceneWithInteraction = false;
            Debug.Log("Times en " + gameObject.name + ": " + GetComponentInParent<sceneManager>().getLocationTimes(gameObject.name));
        }
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
