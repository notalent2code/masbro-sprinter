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
            // Create a new AudioSource component
            s.source = gameObject.AddComponent<AudioSource>();
            // Assign the clip to the AudioSource
            s.source.clip = s.clip;
            // Set the volume
            s.source.volume = s.volume;
            // Set the loop
            s.source.loop = s.loop;
        }

        // Play the background music
        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        // Find the sound in the sounds array
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // Play the sound
        s.source.Play();
    }

    public void StopSound(string name)
    {
        // Find the sound in the sounds array
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // Stop the sound
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
