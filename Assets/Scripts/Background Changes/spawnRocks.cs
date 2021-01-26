using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRocks : MonoBehaviour
{
    public int[] converTimes;
    public Sprite newBackground;
    public float timer;
    public GameObject rocks;
    public GameObject curLocation;

    Tester tester;
    float time;
    sceneManager manager;
    DialogueManager dialogueManager;
    GameObject inventory;
    Transform curBackground;
    int indexActivation;
    bool faded = false;

    private void Start()
    {
        tester = GetComponent<Tester>();
        manager = GameObject.Find("Map Locations").GetComponent<sceneManager>();
        dialogueManager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
        inventory = GameObject.Find("InventoryIcon").gameObject;
        curBackground = transform.Find("InteractiveBackground").transform;
        indexActivation = 0;
    }

    private void Update()
    {
        checkActivation();
    }

    private void checkActivation()
    {
        if(indexActivation < converTimes.Length && tester.index == converTimes[indexActivation] 
            && !dialogueManager.InConvo && !manager.getPuzleState() && !manager.getObjectPuzleState())
        {
            if (!faded)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                inventory.SetActive(false);

                faded = true;
            }

            time += Time.deltaTime;
            if(time >= timer)
            {
                if (faded)
                {
                    curBackground.gameObject.GetComponent<SpriteRenderer>().sprite = newBackground;

                    for (int i = 0; i < curBackground.childCount; i++)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                        inventory.SetActive(true);
                        rocks.SetActive(true);
                    }
                    manager.setLocationTimes(curLocation.name);

                    indexActivation++;
                }
            }
        }
    }
}
