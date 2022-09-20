using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{ 
    private AudioSource _audioSrc;

    private static BGSound source = null;
    public static BGSound Source
    {
        get { return source; }
    }

    void Awake()
    {
        if (source != null && source != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            source = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        _audioSrc = GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
            PlayerPrefs.SetFloat("MusicVolume", 1f);

        _audioSrc.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}