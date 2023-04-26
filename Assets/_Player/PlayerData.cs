using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player", order = 1)]
public class PlayerData : ScriptableObject
{
    public Sprite Icon;
    public string Name;

    public int MaxHealth;
    public float InvincibilityPeriod;
    public int Speed;


    // public WeaponData Weapon;
}
