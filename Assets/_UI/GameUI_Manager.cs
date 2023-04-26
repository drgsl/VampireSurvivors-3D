using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class GameUI_Manager : UI_Manager
{
    public static new GameUI_Manager Instance;

    public Slider PlayerLevelSlider;
    public TextMeshProUGUI PlayerLevelText;

    public Slider PlayerHealthSlider;

    public GameObject DeathScreen;



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
        hideDeathScreen();
    }

    public static void updateLevelBar(int currentXP, int maxXP, int level)
    {
        updateSliderWithText(Instance.PlayerLevelSlider, maxXP, currentXP, Instance.PlayerLevelText, "LV " + level.ToString());
    }
    public static void updateHealthBar(int currentHealth, int maxHealth)
    {
        updateSlider(Instance.PlayerHealthSlider, maxHealth, currentHealth);
    }

    public static void TryAgainButton()
    {
        ScenesHandler.ReloadScene();
    }
    public static void GoToMainMenu()
    {
        ScenesHandler.LoadMainMenu();
    }

    public static void showDeathScreen()
    {
        ShowCursor();
        ShowPanel(Instance.DeathScreen);
    }
    public static void hideDeathScreen()
    {
        HidePanel(Instance.DeathScreen);
    }

}
