using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Value = 0;
    public AudioClipGroup BackgroundMusic;

    private bool endLevel = false;

    private void Awake()
    {
        Events.OnSetValue += OnSetValue;
        Events.OnRequestValue += OnRequestValue;
        Events.OnEndLevel += OnEndLevel;

        BackgroundMusic.PlayBackground();
    }

    public void Update()
    {
        if (endLevel == true)
        {
            BackgroundMusic.StopBackground();
        }
    }

    public void Start()
    {
        Events.SetValue(Value);
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

    void OnHealthDestroyed(GameObject go)
    {

    }

    void OnEndLevel(bool isWin)
    {
        endLevel = true;
    }

}
