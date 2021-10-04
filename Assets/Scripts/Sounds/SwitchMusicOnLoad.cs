using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip NewTrack;
    public float VolumeFloat = 1.0f;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (NewTrack != null)
            audioManager.ChangeBackgroundMusic(NewTrack, VolumeFloat);
    }
}
