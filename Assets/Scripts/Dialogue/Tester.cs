using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public int index;
    public Conversation[] convo;
    public bool sceneWithInteraction = false;

    List<bool> activate;
    sceneManager manager;

    public void Start()
    {
        manager = GetComponentInParent<sceneManager>();
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

            if(!sceneWithInteraction)
                manager.setLocationTimes(gameObject.name);
            Debug.Log("Times en " + gameObject.name + ": " + manager.getLocationTimes(gameObject.name));

            index++;
            if (index < convo.Length)
                activate[index] = true;
        }
    }
}
