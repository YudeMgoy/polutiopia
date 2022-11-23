using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public Slider musicVolume;
    public Slider sfxVolume;

    void Start()
    {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("SfxVolume");
    }

    void Update()
    {
        music.volume = musicVolume.value;
    }

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume",music.volume);
        PlayerPrefs.SetFloat("SfxVolume",sfxVolume.value);
    }
}
