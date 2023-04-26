using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerOption : MonoBehaviour
{
    private PlayerData playerData;
    public Image playerImage;
    public TextMeshProUGUI playerName;
    // public TextMeshProUGUI playerDescription;
    // public Image WeaponImage;

    public void SetPlayerData(PlayerData playerData)
    {
        this.playerData = playerData;
        playerImage.sprite = playerData.Icon;
        playerName.text = playerData.Name;
        // playerDescription.text = playerData.playerDescription;
        // WeaponImage.sprite = playerData.weaponImage;
    }

    public void ChooseThisPlayer()
    {
        PlayerSelectionScreen.ActivatePlayButton();
        DataCarrier.ChosenPlayerData = playerData;
        PlayerSelectionScreen.Instance.PlayerHealthText.text = "MaxHealth: " + playerData.MaxHealth;
    }
}
