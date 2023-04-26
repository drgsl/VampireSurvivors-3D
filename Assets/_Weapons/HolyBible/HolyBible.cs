using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBible : Weapon
{
    public void Awake()
    {
        data = Resources.Load<WeaponData>("Weapons/HolyBibleData");
    }
}
