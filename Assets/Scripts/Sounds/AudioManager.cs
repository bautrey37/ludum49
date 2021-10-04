using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackGroundMusic;

    private float volumeRatio = 1.0f;
    private float gameSettingsVolume = 1.0f;

    private void Awake()
    {
        Events.OnEndLevel += OnEndLevel;
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // make sure only one audio manager is playing music
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        try
        {
            gameSettingsVolume = GameSettings.Instance.Volume;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Game Settings cannot be found; You're playing a scene without going through menu.");
        }
    }

    public void ChangeBackgroundMusic(AudioClip music)
    {
        if (BackGroundMusic.clip.name == music.name) return;
        Debug.Log("gameSettingsVolume: " + gameSettingsVolume);
        BackGroundMusic.Stop();
        BackGroundMusic.clip = music;
        BackGroundMusic.volume = 1.0f * gameSettingsVolume;
        BackGroundMusic.Play();
    }

    public void UpdateVolume(float newVolume)
    {
        if (BackGroundMusic == null) return;
        BackGroundMusic.volume = newVolume;
    }

    private void OnEndLevel(bool IsWin)
    {
        if (BackGroundMusic == null) return;
        BackGroundMusic.Stop();
    }
}
