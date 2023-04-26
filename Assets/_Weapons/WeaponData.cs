using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public Sprite Icon;
    public string Name;

    public int BaseDamage;
    public float DelaySeconds;
}