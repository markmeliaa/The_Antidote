using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMap : MonoBehaviour
{
    [SerializeField] GameObject gameobject;

    void PlaySound(AudioClip whichSound)
    {
        gameobject.GetComponent<AudioSource>().PlayOneShot(whichSound);
    }
}
