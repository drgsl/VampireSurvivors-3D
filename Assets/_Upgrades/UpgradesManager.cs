using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public List <UpgradeData> PossibleUpgrades;

    public static UpgradesManager Instance;

    public Upgrade[] UpgradeSlots;
    public GameObject UpgradesPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpgradeSlots = gameObject.GetComponentsInChildren<Upgrade>();

        int index = 0;
        foreach (Upgrade upgrade in UpgradeSlots)
        {
            upgrade.SetUpgradeData(PossibleUpgrades[index]);
            index++;
        }

        HideUpgradesPanel();
    }

    public static void ShowUpgradesPanel()
    {
        UI_Manager.ShowCursor();
        GameManager.Pause();
        Instance.UpgradesPanel.gameObject.SetActive(true);
    }

    public static void HideUpgradesPanel()
    {
        UI_Manager.HideCursor();
        GameManager.Unpause();
        Instance.UpgradesPanel.gameObject.SetActive(false);
    }

}
