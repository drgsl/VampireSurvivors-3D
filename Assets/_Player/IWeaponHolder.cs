using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHolder
{
    Weapon CurrentWeapon { get; set; }
    List <Weapon> Weapons { get; set; }

    void EquipWeapon(Weapon weapon);
    void UnequipAllWeapons();
    void UnequipWeapon(Weapon weapon);
}