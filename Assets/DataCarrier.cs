using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCarrier: MonoBehaviour
{
    protected static PlayerData chosenPlayerData;

    public static PlayerData ChosenPlayerData
    {
        get { return chosenPlayerData; }
        set { chosenPlayerData = value; }
    }

    private void Awake()
    {
        DataCarrier[] objs = Object.FindObjectsOfType<DataCarrier>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

}
