using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip NewTrack;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (NewTrack != null)
            audioManager.ChangeBackgroundMusic(NewTrack);
    }
}
