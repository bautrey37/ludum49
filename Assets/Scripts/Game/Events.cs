using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    private static bool _winGame;
    public static bool winGame
    {
        get { return _winGame; }
        set { _winGame = value; }
    }

    public static event Action<bool> OnEndLevel;
    public static void EndLevel(bool isWin) => OnEndLevel?.Invoke(isWin);

    public static event Action<bool> OnIsPlayerPlaying;
    public static void IsPlayerPlaying(bool isPlaying) => OnIsPlayerPlaying?.Invoke(isPlaying);


    // public static event Action onPlayerDies;
    // public static void PlayerDies() => onPlayerDies?.Invoke();


    // template events
    public static event Func<int> OnRequestValue;
    public static int RequestValue() => OnRequestValue?.Invoke() ?? 0;
    public static event Action<int> OnSetValue;
    public static void SetValue(int value) => OnSetValue?.Invoke(value);


    public static event Action<bool> OnEndGame;
    public static void EndGame(bool isWin) => OnEndGame?.Invoke(isWin);
}
