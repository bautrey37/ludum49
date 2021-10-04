using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackGroundMusic;

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
    }

    public void ChangeBackgroundMusic(AudioClip music)
    {
        if (BackGroundMusic.clip.name == music.name) return;

        BackGroundMusic.Stop();
        BackGroundMusic.clip = music;
        BackGroundMusic.Play();
        // BackGroundMusic.loop = BackGroundMusic.isPlaying;
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
