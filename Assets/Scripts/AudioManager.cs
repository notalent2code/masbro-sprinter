using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }

        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSoundVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }
}
