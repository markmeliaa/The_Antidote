using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnTVONOFF : MonoBehaviour
{
    private Animator tvAnimator;
    private bool encendidoPrimero = false;
    private AudioSource newsAudio;

    // Start is called before the first frame update
    void Start()
    {
        tvAnimator = GetComponent<Animator>();
        newsAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!tvAnimator.GetBool("tvOn") && !encendidoPrimero)
        {
            StartCoroutine("turnTV");
        }

        if (!tvAnimator.GetBool("tvOn") && encendidoPrimero)
        {
            newsAudio.Stop();
        }
    }

    IEnumerator turnTV()
    {
        yield return new WaitForSeconds(0.65f);
        tvAnimator.SetBool("tvOn", true);
        encendidoPrimero = true;
        yield return new WaitForSeconds(0.1f);
        newsAudio.mute = false;
    }
}
