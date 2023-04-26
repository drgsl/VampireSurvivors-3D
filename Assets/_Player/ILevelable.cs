using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelable
{
    int Level { get; set; }
    int XP { get; set; }
    int XPToNextLevel { get; set; }

    void AddXP(int amount);
    void LevelUp();
}