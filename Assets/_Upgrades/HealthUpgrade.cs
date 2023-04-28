using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HealthUpgrade", menuName = "Upgrades/HealthUpgrade")]
public class HealthUpgrade : UpgradeData
{
    public int MaxHealthIncrease;
    public int HealthIncrease;

    public override void ApplyUpgrade()
    {
        base.ApplyUpgrade();
        Player.Instance.IncreaseMaxHealth(MaxHealthIncrease);
        Player.Instance.Heal(HealthIncrease);
    }
}
