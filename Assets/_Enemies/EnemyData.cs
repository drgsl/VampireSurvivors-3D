using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public GameObject Prefab;

    public Sprite Icon;
    public string Name;

    public int BaseDamage;
    public int Speed;
    public float InvincibilityPeriod = 0.5f;

    public int MaxHealth;

    public int DropChance;
    // public GameObject drop;

    public List<XP_PointData> XP_Drops;
}

public struct XP_DropWeighted
{
    public XP_PointData data;
    public int Chance;
}
