using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfx;
    public AudioClip[] sfxArray;
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
        sfx.volume = sfxVolume.value;
    }

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume",music.volume);
        PlayerPrefs.SetFloat("SfxVolume",sfxVolume.value);
    }
    public void PlayClickAudio()
    {
        sfx.PlayOneShot(sfxArray[0],sfx.volume);
    }
}
