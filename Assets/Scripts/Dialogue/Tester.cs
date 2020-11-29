﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public bool play;
    public int index;
    public Conversation[] convo;

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

            manager.setLocationTimes(gameObject.name);

            index++;
            if (index < convo.Length)
                activate[index] = true;
        }
    }
}
