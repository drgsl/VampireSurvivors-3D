using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public UI_Manager Instance;

    public Slider PlayerLevelSlider;
    public TextMeshProUGUI PlayerLevelText;

    private void Awake()
    {
        if(Instance != null || Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void initSlider(int maxValue, string text, int value = 0)
    {
        PlayerLevelSlider.maxValue = maxValue;
        PlayerLevelSlider.value = value;
        PlayerLevelText.text = "LV " + text;
    }
}
