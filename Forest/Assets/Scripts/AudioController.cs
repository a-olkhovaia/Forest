using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider sliderMusic;
    public AudioClip music;
    public AudioSource audio;

    void Update()
    {
        audio.volume = sliderMusic.value;
    }

    public void PlaySound()
    {
        audio.PlayOneShot(music);
    }
}
