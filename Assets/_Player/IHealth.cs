using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    int Health { get; set; }
    int MaxHealth { get; set; }

    void TakeDamage(int damage);
    void Heal(int heal);
    void Die();
}
