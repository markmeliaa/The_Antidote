using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public GameObject[] dialogueLocations;

    private AutomaticDialogs nextDialogueScript;
    private Tester nextConvoScript;
    private void OnMouseDown()
    {
        for (int i = 0; i < dialogueLocations.Length; i++)
        {
            nextDialogueScript = dialogueLocations[i].GetComponent<AutomaticDialogs>();
            nextConvoScript = dialogueLocations[i].GetComponent<Tester>();

            if (nextDialogueScript != null)
            {
                nextDialogueScript.activated = false;
                nextConvoScript.play = true;
            }
        }
        
    }
}
