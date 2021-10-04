using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerCheck : MonoBehaviour
{
    public GameObject AudioManager;

    void Start()
    {
        if(FindObjectOfType<AudioManager>()) return;
        else
            Instantiate(AudioManager, transform);
    }
}
