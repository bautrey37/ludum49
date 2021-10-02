using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int Value = 0;
    public BackgroundAudio BackgroundMusic;

    private SceneLoader sceneLoader;
    private bool endLevel = false;

    private void Awake()
    {
        Events.OnSetValue += OnSetValue;
        Events.OnRequestValue += OnRequestValue;
        Events.OnEndLevel += OnEndLevel;


        BackgroundMusic.Play();
    }

    public void Start()
    {
        Events.SetValue(Value);
        sceneLoader = gameObject.GetComponent<SceneLoader>();
    }

    public void Update()
    {
        if (endLevel == true)
        {
            BackgroundMusic.Stop();
        }
    }

    private void OnDestroy()
    {
        Events.OnSetValue -= OnSetValue;
        Events.OnRequestValue -= OnRequestValue;
        Events.OnEndLevel -= OnEndLevel;
    }

    private void OnSetValue(int amount)
    {
        Value = amount;
    }

    private int OnRequestValue()
    {
        return Value;
    }

    private void OnEndLevel(bool isWin)
    {
        Debug.Log("End level");
        // restart scene
        sceneLoader.restartScene();
        endLevel = isWin;
    }

}
