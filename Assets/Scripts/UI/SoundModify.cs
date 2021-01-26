using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SoundModify : MonoBehaviour
{
    public AudioMixer mixer;
    public TextMeshProUGUI volumeLevel;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);

        float actualValue = sliderValue * 100;

        volumeLevel.text = (Mathf.Round(actualValue)).ToString();
    }
}
