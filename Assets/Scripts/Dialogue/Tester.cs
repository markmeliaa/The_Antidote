using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public GameObject convoButton;
    public int index;
    public Conversation[] convo;
    public bool play = false;

    List<bool> activate;

    public void Start()
    {
        activate = new List<bool>();

        activate.Add(true);
        for (int i = 1; i < convo.Length; i++)
        {
            activate.Add(false);
        }
    }
    public void starConvo()
    {
        if (activate[index] && play)
        {
            DialogueManager.StartConversation(convo[index]);

            play = false;
            index++;
            if (index < convo.Length)
                activate[index] = true;
        }
    }

    public void destroyButton()
    {
        Destroy(convoButton);
    }

    public void activeConvo()
    {
        play = true;
    }
}
