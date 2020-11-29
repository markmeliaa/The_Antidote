using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDialogs : MonoBehaviour
{
    public float finalTime;
    public bool activated = false;
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
        Debug.Log(locConditions[tester.index].name + " estado: " + sceneManager.getLocationBool(locConditions[tester.index].name) + " y " + sceneManager.getLocationTimes(locConditions[tester.index].name));

        if (sceneManager.getLocationBool(locConditions[tester.index].name) 
            && sceneManager.getLocationTimes(locConditions[tester.index].name) == timesVisited[tester.index] 
            && tester.index < tester.convo.Length)
        {
            timer += Time.deltaTime;

            if (timer >= finalTime)
            {
                timer = 0;
                tester.starConvo();
            }
        }
    }
}
