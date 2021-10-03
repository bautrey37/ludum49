using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DropdownMenu : MonoBehaviour
{
    public Button dropDown;
    public Button dropUp;
    public Button exit;
    public Button restart;
    public Button info;
    public Button cancel;

    public GameObject menu;
    public GameObject tutorial;

    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        dropUp.gameObject.SetActive(false);
        tutorial.SetActive(false);

        dropDown.onClick.AddListener(ShowMenu);
        dropUp.onClick.AddListener(CloseMenu);
        exit.onClick.AddListener(StartScene);
        restart.onClick.AddListener(Restart);
        info.onClick.AddListener(ShowTutorial);
        cancel.onClick.AddListener(CloseTutorial);

        sceneLoader = gameObject.GetComponent<SceneLoader>();
    }

    private void CloseTutorial()
    {
        tutorial.SetActive(false);
    }

    private void ShowTutorial()
    {
        tutorial.SetActive(true);
    }

    private void Restart()
    {
        sceneLoader.RestartScene();
    }

    private void StartScene()
    {
        sceneLoader.LoadMenu();
    }

    private void CloseMenu()
    {
        dropDown.gameObject.SetActive(true);
        menu.SetActive(false);
        dropUp.gameObject.SetActive(false);
    }

    private void ShowMenu()
    {
        dropDown.gameObject.SetActive(false);
        menu.SetActive(true);
        dropUp.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
