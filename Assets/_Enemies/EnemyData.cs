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

    public int MaxHealth;

    public int DropChance;
    public GameObject drop;
}
