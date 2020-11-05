using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation convo;
    public GameObject convoButton;

    public void starConvo()
    {
        DialogueManager.StartConversation(convo);
    }

    public void destroyButton()
    {
        Destroy(convoButton);
    }
}
