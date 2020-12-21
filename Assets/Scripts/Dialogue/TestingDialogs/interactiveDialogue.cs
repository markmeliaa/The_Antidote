using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveDialogue : MonoBehaviour
{
    public GameObject location;
    public DialogueManager dialogueManager;
    public bool notDestroy = false;
    private void OnMouseDown()
    {
        if(!location.GetComponent<sceneManager>().getPuzleState() && !dialogueManager.InConvo)
        {
            location.GetComponentInParent<sceneManager>().setLocationTimes(location.name);
            location.GetComponent<Tester>().sceneWithInteraction = false;
            if (!notDestroy)
                Destroy(gameObject);
            else
                notDestroy = false;
        }
    }
}
