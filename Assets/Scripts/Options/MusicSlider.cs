using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    private AudioSource _audioSrc;
    private Slider _slider;


    private float _musicValue = 1f;

    private void Start()
    {
        _audioSrc = BGSound.Source.gameObject.GetComponent<AudioSource>();
        _slider = GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    private void Update()
    {
        _audioSrc.volume = _musicValue;
    }
    public void SetValue(float _sliderValue)
    {
        _musicValue = _sliderValue;
        PlayerPrefs.SetFloat("MusicVolume", _musicValue);
    }
}