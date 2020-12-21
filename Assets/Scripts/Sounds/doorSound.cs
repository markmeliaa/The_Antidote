using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSound : MonoBehaviour
{
    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        sound.Play();
    }
}
