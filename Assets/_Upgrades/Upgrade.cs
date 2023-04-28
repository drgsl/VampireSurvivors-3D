using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Upgrade : MonoBehaviour
{
    public UpgradeData Data;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;

    // public Image Icon;

    public void SetUpgradeData (UpgradeData newData)
    {
        Data = newData;

        NameText.text = Data.Name;
        DescriptionText.text = Data.Description;
        // Icon.sprite = Data.Icon;
    }

    public void OnButtonPress()
    {
        Data.ApplyUpgrade();
        UpgradesManager.HideUpgradesPanel();
    }
}
