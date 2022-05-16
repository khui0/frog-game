using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    bool currentMuteStatus;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        PlaySound("Music");
    }

    private void Update()
    {
        if (currentMuteStatus != MuteAudio.isAudioMuted)
        {
            currentMuteStatus = MuteAudio.isAudioMuted;

            if (MuteAudio.isAudioMuted)
            {
                PauseSound("Music");
            }
            else
            {
                UnpauseSound("Music");
            }
        }
    }

    public void PlaySound (string name)
    {
        if (!MuteAudio.isAudioMuted)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }

    void PauseSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }

    void UnpauseSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }
}
