using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSelectionScreen : MonoBehaviour
{
    public static PlayerSelectionScreen Instance;

    private PlayerData[] playerTypes;
    private GameObject playerOptionPrefab;
    private Transform playerOptionsContainer;

    public Button StartButton;

    public TextMeshProUGUI PlayerHealthText;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;


        playerTypes = Resources.LoadAll<PlayerData>("Players/");
        playerOptionPrefab = Resources.Load<GameObject>("UI/Player Selector/PlayerOption");
        playerOptionsContainer = gameObject.GetComponentInChildren<GridLayoutGroup>().transform;

        initPlayerOptions();
        DeactivatePlayButton();
    }

    private void initPlayerOptions()
    {
        foreach (PlayerData playerData in playerTypes)
        {
            GameObject newPlayerOption = Instantiate(playerOptionPrefab, playerOptionsContainer);
            PlayerOption playerOption = newPlayerOption.GetComponent<PlayerOption>();
            playerOption.SetPlayerData(playerData);
        }
    }

    public static void ActivatePlayButton()
    {
        Instance.StartButton.interactable = true;
    }
    public static void DeactivatePlayButton()
    {
        Instance.StartButton.interactable = false;
    }

}
