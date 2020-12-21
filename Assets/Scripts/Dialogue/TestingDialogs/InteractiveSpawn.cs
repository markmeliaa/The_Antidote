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

    private void Start()
    {
        tester = GetComponent<Tester>();
        indexActivation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkActivation();
    }

    private void checkActivation()
    {
        if(indexActivation < converTimes.Length && tester.index == converTimes[indexActivation])
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
