using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioManager AM;

    private float volume;

    private void Start()
    {
        volume = GameSettings.Instance.Volume;
        VolumeSlider.value = volume;
    }

    public void UpdateTitleVolume(float newVolume)
    {
        if (AM == null)
        {
            Debug.Log("Audio Manager doesn't exist");
            AM = FindObjectOfType<AudioManager>();
        }
        AM.UpdateVolume(newVolume);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
