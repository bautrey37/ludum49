using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPresenter : MonoBehaviour
{
    public GameObject EndGamePanel;
    public GameObject SuccessGamePanel;

    public AudioClipGroup AudioDead;
    public AudioClipGroup AudioWin;

    private bool isWin;
    private SceneLoader sceneLoader;

    private void Awake()
    {
        EndGamePanel.SetActive(false);
        SuccessGamePanel.SetActive(false);
        // Events.OnEndLevel += OnEndLevel;
    }

    private void Start()
    {
        sceneLoader = gameObject.GetComponent<SceneLoader>();
        isWin = Events.winGame;
        Debug.Log("Showing game condition: " + isWin);
        if (isWin)
        {
            WinGame();
        } else
        {
            LoseGame();
        }
    }

    private void OnDestroy()
    {
        // Events.OnEndLevel -= OnEndLevel;
    }

    void WinGame()
    {
        SuccessGamePanel.SetActive(true);

        // AudioWin.Play();
    }

    void LoseGame()
    {
        EndGamePanel.SetActive(true);

        AudioDead.Play();
    }

    public void GoToMenu()
    {
        sceneLoader.LoadMenu();
    }
}
