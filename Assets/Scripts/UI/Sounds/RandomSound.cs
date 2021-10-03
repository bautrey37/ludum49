using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    public List<AudioClip> clip_list;

    private AudioSource source;
    private float volume = 0.7f;
    private float sound_playing_probability = 0.005f;
    volatile private bool did_sound_play = false;

    // Start is called before the first frame update
    void Start()
    {
        try {
            volume = GameSettings.Instance.Volume + 0.7f;
        }
        catch (System.Exception e) {
            Debug.LogWarning("Game Settings cannot be found; You're playing a scene without going through menu.");
        }

        source = AudioSourcePool.Instance.GetSource();

        source.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
            if (Random.value <= sound_playing_probability && !did_sound_play) {    
            StartCoroutine("SoundCoroutine");
            
        }
    }

    IEnumerator SoundCoroutine() {
        did_sound_play = true;
        source.PlayOneShot(clip_list[Random.Range(0, clip_list.Count)]);
        yield return new WaitForSeconds(16);
        did_sound_play = false;
    }
}
