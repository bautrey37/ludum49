using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider VolumeSlider;
    public BackgroundAudio TitleAudio;

    private float volume;

    private void Start()
    {
        volume = GameSettings.Instance.Volume;
        VolumeSlider.value = volume;
        TitleAudio.Play();
    }

    public void UpdateTitleVolume(float newVolume)
    {
        TitleAudio.UpdateVolume(newVolume);
    }

    public void PlayGame()
    {
        TitleAudio.Stop();
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
