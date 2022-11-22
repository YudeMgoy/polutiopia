using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public Slider volume;
    public Slider sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("SfxVolume");    
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = volume.value;
    }

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume",music.volume);
        PlayerPrefs.SetFloat("SfxVolume",sfxVolume.value);
    }
}
