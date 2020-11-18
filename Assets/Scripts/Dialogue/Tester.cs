using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public GameObject convoButton;
    [SerializeField] private Conversation[] convo;
    List<bool> activate;
    int index = 0;

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
        if (activate[index])
        {
            DialogueManager.StartConversation(convo[index]);

            index++;
            if (index < convo.Length)
                activate[index] = true;
            else
                index = 0;
        }
    }

    public void destroyButton()
    {
        Destroy(convoButton);
    }
}
