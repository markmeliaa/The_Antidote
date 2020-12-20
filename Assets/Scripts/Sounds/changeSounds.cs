using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSounds : MonoBehaviour
{
    private AudioSource mainGameAudio;

    // Start is called before the first frame update
    void Start()
    {
        mainGameAudio = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        mainGameAudio.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainGameAudio.mute != true)
            mainGameAudio.mute = true;
    }
}
