using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfx;
    public AudioClip[] sfxArray;
    // public List<AudioSource> sfxSound = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
        sfx.volume = PlayerPrefs.GetFloat("SfxVolume");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClickAudio()
    {
        sfx.PlayOneShot(sfxArray[0],sfx.volume);
    }
}
