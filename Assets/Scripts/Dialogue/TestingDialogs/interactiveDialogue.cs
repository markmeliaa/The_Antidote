using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveDialogue : MonoBehaviour
{
    public GameObject interactiveItem;
    public GameObject location;
    public DialogueManager dialogueManager;
    public bool notDestroy = false;
    private void OnMouseDown()
    {
        if(!location.GetComponentInParent<sceneManager>().getPuzleState() && !dialogueManager.InConvo)
        {
            location.GetComponentInParent<sceneManager>().setLocationTimes(location.name);
            location.GetComponent<Tester>().sceneWithInteraction = false;
            if (!notDestroy)
            {
                Destroy(interactiveItem);
                Destroy(gameObject);
            }
            else
            {
                notDestroy = false;
                interactiveItem.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
