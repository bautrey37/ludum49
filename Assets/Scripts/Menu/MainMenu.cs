using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider Volume;

    // private void Awake()
    // {
    //     Volume = gameObject.GetComponent<Slider>();
    // }

    private void Start()
    {
        Volume.value = GameSettings.Instance.Volume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("AntonMap");
    }

    public void AdjustVolume()
    {

    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}
