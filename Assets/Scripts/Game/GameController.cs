using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void Awake()
    {
        Events.OnEndLevel += OnEndLevel;
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    public void Start()
    {
        sceneLoader = gameObject.GetComponent<SceneLoader>();
        // BackgroundAudio.Play();
        // if (BackgroundAudio == null)
        // {
        //     BackgroundAudio = gameObject.GetComponent<BackgroundAudio>();
        // }
    }

    private void OnEndLevel(bool isWin)
    {
        Events.winGame = isWin;
        sceneLoader.LoadEndGame();
    }
}
