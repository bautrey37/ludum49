using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public int Value = 0;
    public BackgroundAudio BackgroundAudio;

    private SceneLoader sceneLoader;
    private bool endLevel = false;

    private void Awake()
    {
        // Events.OnSetValue += OnSetValue;
        // Events.OnRequestValue += OnRequestValue;
        Events.OnEndLevel += OnEndLevel;

        BackgroundAudio.Play();
    }

    public void Start()
    {
        // Events.SetValue(Value);
        sceneLoader = gameObject.GetComponent<SceneLoader>();
    }

    public void Update()
    {
        if (endLevel == true)
        {
            BackgroundAudio.Stop();
        }
    }

    private void OnDestroy()
    {
        // Events.OnSetValue -= OnSetValue;
        // Events.OnRequestValue -= OnRequestValue;
        Events.OnEndLevel -= OnEndLevel;
    }

    private void OnEndLevel(bool isWin)
    {
        Debug.Log("End level");

        sceneLoader.RestartScene();
        endLevel = isWin;
    }

    // private void OnSetValue(int amount)
    // {
    //     Value = amount;
    // }

    // private int OnRequestValue()
    // {
    //     return Value;
    // }

}
