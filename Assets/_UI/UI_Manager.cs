using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public static void updateSliderWithText(Slider slider, int maxValue, int Value, TextMeshProUGUI TextComponent, string text)
    {
        slider.maxValue = maxValue;
        slider.value = Value;
        TextComponent.text = text;
    }
    public static void updateSlider(Slider slider, int maxValue, int Value)
    {
        slider.maxValue = maxValue;
        slider.value = Value;
    }

    public static void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public static void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }


    public static void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
    }
    public static void HideScreen(GameObject screen)
    {
        screen.SetActive(false);
    }
    

    

    public static void PauseTime()
    {
        Time.timeScale = 0;
    }
    public static void ResumeTime()
    {
        Time.timeScale = 1;
    }


    public static void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public static void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
