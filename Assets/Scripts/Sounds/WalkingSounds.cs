using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkingSounds : MonoBehaviour {

    public Transform target;
    public Tilemap background_tile_map;
    public Tilemap pathway_tile_map;
    public AudioClip grass_sound;
    public AudioClip pavement_sound;

    private AudioSource source;
    private float volume = 0.7f;

    // Start is called before the first frame update
    Vector3Int position;
    void Start() {
        if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}

        try
        {
            volume = GameSettings.Instance.Volume + 0.7f;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Game Settings cannot be found; You're playing a scene without going through menu.");
        }

        source = AudioSourcePool.Instance.GetSource();

        source.volume = volume;
        source.clip = pavement_sound; // The player starts on the pavement
        position = Vector3Int.RoundToInt(target.transform.position);
    }

    // Update is called once per frame
    void Update() {
        Vector3Int new_position = Vector3Int.RoundToInt(target.transform.position);
        if (new_position != position) {
            position = new_position;
            if (background_tile_map.GetTile(position)) {
                CheckIfSoundIsPlaying(grass_sound);
            }
            if (pathway_tile_map.GetTile(position)) {
                CheckIfSoundIsPlaying(pavement_sound);
            }
        }
    }

    IEnumerator MusicCoroutine() {
        source.Play();
        yield return new WaitForSeconds(1);
        source.Pause();
    }

    void CheckIfSoundIsPlaying(AudioClip clip) {
        if (source.clip != clip) {
                    source.Stop();
                    source.clip = clip;
                    StartCoroutine("MusicCoroutine");
                } else {
                    if (!source.isPlaying) {
                        StartCoroutine("MusicCoroutine");
                    }
                }
    } 
}
