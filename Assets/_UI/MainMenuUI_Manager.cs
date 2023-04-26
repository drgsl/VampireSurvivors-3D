using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI_Manager : UI_Manager
{
    public static new MainMenuUI_Manager Instance;

    public GameObject MainMenuScreen;
    public GameObject OptionsScreen;

    public GameObject PlayerSelectionScreen;
    // public GameObject LevelSelectionScreen;

    public GameObject QuitConfirmationPanel;


    protected new virtual void Awake()
    {
        // base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SwitchToMainMenu();
    }

    public static void SwitchToMainMenu()
    {
        SwitchScreen(Instance.MainMenuScreen);
    }
    public static void SwitchToOptions()
    {
        SwitchScreen(Instance.OptionsScreen);
    }
    public static void SwitchToPlayerSelection()
    {
        SwitchScreen(Instance.PlayerSelectionScreen);
    }
    public static void SwitchToLevelSelection()
    {
        // SwitchScreen(Instance.LevelSelectionScreen);
    }

    public static void StartGame()
    {
        ScenesHandler.LoadScene(1);
    }

    public static void ShowQuitConfirmation()
    {
        ShowPanel(Instance.QuitConfirmationPanel);
    }
    public static void HideQuitConfirmation()
    {
        HidePanel(Instance.QuitConfirmationPanel);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }


    private static void SwitchScreen(GameObject screen)
    {
        HideAllScreens();
        ShowScreen(screen);
    }

    private static void HideAllScreens()
    {
        HideScreen(Instance.MainMenuScreen);
        HideScreen(Instance.OptionsScreen);
        HideScreen(Instance.PlayerSelectionScreen);
        // HideScreen(Instance.LevelSelectionScreen);
    }

}
