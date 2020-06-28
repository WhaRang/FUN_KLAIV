﻿using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

       foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        if (!(s.source.isPlaying && s.single)) {
            s.source.Play();
        }
    }
}
