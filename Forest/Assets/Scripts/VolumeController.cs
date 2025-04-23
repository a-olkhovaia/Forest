using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VolumeController : MonoBehaviour
{
    public string volumeParametr = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private float _volumeValue;
    private const float _multiplier = 20f;

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParametr, _volumeValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParametr, Mathf.Log10(slider.value) * _multiplier);
        slider.value = Mathf.Pow(10F, _volumeValue/_multiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParametr, _volumeValue);
    }
}
