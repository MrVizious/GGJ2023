using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using ExtensionMethods;

public class AudioController : Singleton<AudioController>
{
    public List<AudioClip> musicaBG = new List<AudioClip>();
    public List<AudioClip> SoundsSFX = new List<AudioClip>();
    public List<AudioClip> AmbientSFXMedieval = new List<AudioClip>();
    public List<AudioClip> AmbientSFXVictorian = new List<AudioClip>();
    public List<AudioClip> AmbientSFXModern = new List<AudioClip>();
    public List<AudioClip> AmbientSFXFuturistic = new List<AudioClip>();

    public int Epoca = 0;

    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;
    public AudioSource AmbientAudioSource;

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

    public void PlayAmbientSound()
    {
        if (Random.Range(0, 10.0f) < 7.0)
        {
            switch (Epoca)
            {
                case 0:
                    AmbientAudioSource.PlayOneShot(AmbientSFXMedieval.GetRandomItem<AudioClip>());
                    break;
                case 1:
                    AmbientAudioSource.PlayOneShot(AmbientSFXVictorian.GetRandomItem<AudioClip>());
                    break;
                case 2:
                    AmbientAudioSource.PlayOneShot(AmbientSFXModern.GetRandomItem<AudioClip>());
                    break;
                case 3:
                    AmbientAudioSource.PlayOneShot(AmbientSFXFuturistic.GetRandomItem<AudioClip>());
                    break;
            }
        }
    }

}