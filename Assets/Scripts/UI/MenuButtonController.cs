using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Press Up or Down
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                // Down
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                        index++;
                    else
                        index = 0;
                }

                // Up
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                        index--;
                    else
                        index = maxIndex;
                }
            }

            keyDown = true;
        }

        else
            // Don't move continually
            keyDown = false;
    }
}
