using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPresenter : MonoBehaviour
{
    public GameObject EndGamePanel;
    public GameObject SuccessGamePanel;

    private void Awake()
    {
        gameObject.SetActive(false);
        EndGamePanel.SetActive(false);
        SuccessGamePanel.SetActive(false);

        Events.OnEndLevel += OnEndLevel;
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    // Only one level at the moment
    void OnEndLevel(bool isWin)
    {
        Debug.Log("EndingPresenter OnEndLevel");
        if (isWin)
        {
            WinLevel();
        } else
        {
            LoseLevel();
        }
    }

    void WinLevel()
    {
        SuccessGamePanel.SetActive(true);
        gameObject.SetActive(true);
    }

    void LoseLevel()
    {
        EndGamePanel.SetActive(true);
        gameObject.SetActive(true);
    }
}
