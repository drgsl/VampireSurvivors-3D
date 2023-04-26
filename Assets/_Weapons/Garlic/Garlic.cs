using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garlic : Weapon
{
    public void Awake()
    {
        data = Resources.Load<WeaponData>("Weapons/GarlicData");
    }

}
