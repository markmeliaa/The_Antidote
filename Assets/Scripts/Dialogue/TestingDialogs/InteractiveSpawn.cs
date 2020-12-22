using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSpawn : MonoBehaviour
{
    public int[] converTimes;

    public GameObject[] interactiveObject;
    public float timer;

    Tester tester;
    int indexActivation;
    float time;
    sceneManager manager;
    DialogueManager dialogueManager;

    private void Start()
    {
        tester = GetComponent<Tester>();
        indexActivation = 0;
        manager = GameObject.Find("Map Locations").GetComponent<sceneManager>();
        dialogueManager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkActivation();
    }

    private void checkActivation()
    {
        if(indexActivation < converTimes.Length && tester.index == converTimes[indexActivation]
            && !manager.getPuzleState() && !dialogueManager.InConvo)
        {
            time += Time.deltaTime;
            if (time > timer)
            {
                time = 0;
                interactiveObject[indexActivation].SetActive(true);
                indexActivation++;
            }
        }
    }
}
