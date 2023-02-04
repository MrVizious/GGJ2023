using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class AudioController : Singleton<AudioController>
{
    public AudioClip[] musicaBG = new AudioClip[4];
    public AudioClip[] SoundsSFX = new AudioClip[10];

    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;

    public static AudioController instance;

    private void Start()
    {
        AudioController.Instance.ChangeMusic(musicaBG[0]);
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        SFXAudioSource.PlayOneShot(sfxClip);
    }

    public void ChangeMusic(AudioClip musicClip)
    {
        MusicAudioSource.Stop();
        MusicAudioSource.clip = musicClip;
        MusicAudioSource.Play();
    }


}