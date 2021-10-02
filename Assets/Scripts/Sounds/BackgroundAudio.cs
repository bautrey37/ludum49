using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Audio/Background")]
public class BackgroundAudio : ScriptableObject
{
    public AudioClip backgroundAudioClip;

    public void Play()
    {
        if (AudioSourcePool.Instance == null) return;

        // Volume = GameSettings.Instance.Volume is null ? 1f : GameSettings.Instance.Volume;

        Debug.Log("playing background music");
        Debug.Log("audio settings" + GameSettings.Instance.Volume);

        backgroundAudioClip = AudioSourcePool.Instance.GetSource();
        backgroundAudioClip.volume = 1f;
        backgroundAudioClip.pitch = 1;
        // backgroundSource.clip = Clips[Random.Range(0, Clips.Count)];
        backgroundAudioClip.PlayDelayed(1.0f);

        backgroundAudioClip.loop = backgroundAudioClip.isPlaying;
    }

    public void Stop()
    {
        if (backgroundAudioClip == null) return;
        backgroundAudioClip.Stop();
    }
}
