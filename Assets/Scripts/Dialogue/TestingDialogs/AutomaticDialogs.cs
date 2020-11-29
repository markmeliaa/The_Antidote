using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDialogs : MonoBehaviour
{
    public float finalTime;
    public GameObject[] locConditions;
    public int[] timesVisited;

    float timer;
    

    Tester tester;

    sceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GetComponentInParent<sceneManager>();
        tester = GetComponent<Tester>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tester.index < tester.convo.Length && sceneManager.getLocationBool(locConditions[tester.index].name) 
            && sceneManager.getLocationTimes(locConditions[tester.index].name) == timesVisited[tester.index])
        {
            timer += Time.deltaTime;

            if (timer >= finalTime)
            {
                if (tester.index < locConditions.Length - 1 && locConditions[tester.index + 1].name == gameObject.name)
                {
                    tester.sceneWithInteraction = true;    
                }

                timer = 0;
                tester.starConvo();
            }
        }
    }
}
