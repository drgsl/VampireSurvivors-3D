using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeData : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;

    public virtual void ApplyUpgrade()
    {
        Debug.Log("Upgrade applied");
    }
}
