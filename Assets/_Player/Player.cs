using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IWeaponHolder, IHealth, ILevelable
{
    // Singleton
    public static Player Instance { get; private set; }
    
    // IHealth
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public PlayerData data;

    private bool Invincible = false;

    // IWeaponHolder
    public Weapon CurrentWeapon { get; set; }
    public List<Weapon> Weapons { get; set; }

    // ILevelable
    public int Level { get; set; }
    public int XP { get; set; }
    public int XPToNextLevel { get; set; }


    // Monobehaviour
    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;

        if(DataCarrier.ChosenPlayerData != null)
        {
            data = DataCarrier.ChosenPlayerData;
        }

        // IHealth
        MaxHealth = data.MaxHealth;
        Health = MaxHealth;

        // IWeaponHolder
        Weapons = new List<Weapon>();
        Weapons.AddRange(GetComponentsInChildren<Weapon>());
        EquipWeapon(Weapons[0]);

        // ILevelable
        Level = 1;
        XP = 0;
        XPToNextLevel = 100;
    }
    private void Start()
    {
        // UI
        GameUI_Manager.updateLevelBar(XP, XPToNextLevel, Level);
        GameUI_Manager.updateHealthBar(Health, MaxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(Weapons[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(Weapons[1]);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(Invincible)
        {
            return;
        }

        if (collision.gameObject.CompareTag("DamagePlayer"))
        {
            TakeDamage(10);
            StartCoroutine(Invincibility(data.InvincibilityPeriod));
        }
    }
    private IEnumerator Invincibility(float seconds)
    {
        Invincible = true;
        yield return new WaitForSeconds(seconds);
        Invincible = false;
    }

    // ILevelable
    public void AddXP(int amount)
    {
        XP += amount;
        GameUI_Manager.updateLevelBar(XP, XPToNextLevel, Level);
        if (XP >= XPToNextLevel)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        Level++;
        XP = 0;
        XPToNextLevel = XPToNextLevel * 2;
        GameUI_Manager.updateLevelBar(XP, XPToNextLevel, Level);
        UpgradesManager.ShowUpgradesPanel();
    }
    // IHealth
    public void TakeDamage(int damage)
    {
        Health -= damage;
        GameUI_Manager.updateHealthBar(Health, MaxHealth);
        if (Health <= 0)
        {
            Die();
        }
    }
    public void Heal(int heal)
    {
        Health += heal;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        GameUI_Manager.updateHealthBar(Health, MaxHealth);
    }
    public void IncreaseMaxHealth(int amount)
    {
        MaxHealth += amount;
        GameUI_Manager.updateHealthBar(Health, MaxHealth);
    }
    public void Die()
    {
        GameUI_Manager.showDeathScreen();
    }

    // IWeaponHolder
    public void EquipWeapon(Weapon weapon)
    {
        UnequipAllWeapons();
        weapon.gameObject.SetActive(true);
        CurrentWeapon = weapon;
    }
    public void UnequipAllWeapons()
    {
        foreach (Weapon weapon in Weapons)
        {
            UnequipWeapon(weapon);
        }
    }
    public void UnequipWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(false);
    }
}
