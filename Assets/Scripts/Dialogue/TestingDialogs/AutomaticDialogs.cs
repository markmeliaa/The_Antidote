using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDialogs : MonoBehaviour
{
    public float finalTime;

    float timer;
    bool activated = false;

    Tester tester;

    // Start is called before the first frame update
    void Start()
    {
        tester = GetComponent<Tester>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            timer += Time.deltaTime;

            if (timer >= finalTime)
            {
                timer = 0;
                activated = true;
                tester.starConvo();
            }
        }
    }
}
