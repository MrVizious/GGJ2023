using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] musicaBG = new AudioClip[4];
    public AudioClip[] SonidosSFX = new AudioClip[10];

    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;

    public static AudioController instance;

    private void Start()
    {
         AudioController.instance.ChangeMusic(musicaBG[0]);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void PlaySFX(AudioClip sfxClip)
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