using IntoTheLight.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController
{
    public Slider VolumeSlider;
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    public float Volume = 1f;
    public SoundType[] Sounds;

    public  SoundController(Slider VolumeSlider,
        AudioSource SoundEffect,
        AudioSource SoundMusic,
        SoundType[] Sounds)
    {
        this.VolumeSlider = VolumeSlider;
        this.SoundEffect = SoundEffect;
        this.SoundMusic = SoundMusic;
        this.Sounds = Sounds;
        PlayMusic(global::Sounds.music);
        Volume= VolumeSlider.value;
        SetVolume(Volume);
    }

    
    public void SetVolume(float volume)
    {
        Volume = volume;
        SoundEffect.volume = Volume;
        SoundMusic.volume = Volume;
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public void Play(Sounds sound)
    {
        

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
                SoundEffect.loop = false;
                SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType returnsound = Array.Find(Sounds, item => item.soundType == sound);
        if (returnsound != null)
        {
            return returnsound.soundclip;
        }
        return null;
    }

    public void StopEffect()
    {
        SoundEffect.Stop();
    }
}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundclip;
}
public enum Sounds
{
    ButtonClick,
    PlayerDied,
    music,
    LevelFinished,
    LevelStarted,

}

