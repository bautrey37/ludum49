using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Audio/Background")]
public class BackgroundAudio : ScriptableObject
{
    public AudioClip backgroundAudioClip;

    private AudioSource source;
    private float volume = 0.5f;

    public void Update()
    {

    }

    public void Play()
    {
        if (backgroundAudioClip == null) return;

        try
        {
            volume = GameSettings.Instance.Volume;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Game Settings cannot be found; Your playing a scene without going through menu.");
        }

        source = AudioSourcePool.Instance.GetSource();

        source.volume = volume;
        source.clip = backgroundAudioClip;
        source.PlayDelayed(1.0f);

        source.loop = source.isPlaying;
    }

    public void UpdateVolume(float newVolume)
    {
        if (source == null) return;
        source.volume = newVolume;
    }

    public void Stop()
    {
        if (source == null) return;
        source.Stop();
    }
}
