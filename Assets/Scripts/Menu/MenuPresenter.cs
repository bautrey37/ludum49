using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPresenter : MonoBehaviour
{
    public MainMenu MainMenu;
    // public AudioClipGroup MenuBackgroundSound;
    // public AudioClipGroup ButtonClickSound;

    void Start()
    {
        // MenuBackgroundSound.PlayBackground();
        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (Button b in buttons)
        {
            b.onClick.AddListener(PlayButtonSound);
        }
    }

    void PlayButtonSound()
    {
        // ButtonClickSound.Play();
    }
}
