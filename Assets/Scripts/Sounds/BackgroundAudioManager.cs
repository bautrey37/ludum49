// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BackgroundAudioManager : MonoBehaviour
// {
//     public BackgroundAudio BackgroundAudio;

//     public AudioClip GameAudio;
//     public AudioClip TitleAudio;

//     private AudioSource source;
//     private float volume = 0.5f;

//     private void Awake()
//     {
//         Events.OnIsPlayerPlaying += OnIsPlayerPlaying;
//         Events.OnEndLevel += OnEndLevel;
//     }

//     private void OnDestroy()
//     {
//         Events.OnIsPlayerPlaying -= OnIsPlayerPlaying;
//         Events.OnEndLevel -= OnEndLevel;
//     }

//     void Start()
//     {
//         DontDestroyOnLoad(gameObject);
//     }

//     private void OnIsPlayerPlaying(bool playing)
//     {
//         if (playing == false)
//         {
//             BackgroundAudio.Stop();
//         }
//         else
//         {
//             BackgroundAudio.Play();
//         }
//     }

//     private void OnEndLevel()
//     {
//         BackgroundAudio.Stop();
//     }


//     public void Play(AudioClip clip)
//     {
//         if (clip == null) return;

//         try
//         {
//             volume = GameSettings.Instance.Volume;
//         }
//         catch (Exception e)
//         {
//             Debug.LogWarning("Game Settings cannot be found; You're playing a scene without going through menu.");
//         }

//         source = AudioSourcePool.Instance.GetSource();

//         source.volume = volume;
//         source.clip = clip;
//         source.PlayDelayed(1.0f);

//         source.loop = source.isPlaying;
//     }

//     public void PlayTitle()
//     {

//     }

//     public void UpdateVolume(float newVolume)
//     {
//         if (source == null) return;
//         source.volume = newVolume;
//     }

//     public void Stop()
//     {
//         if (source == null) return;
//         source.Stop();
//     }
// }
