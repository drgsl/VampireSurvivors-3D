using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Point : MonoBehaviour
{
    public XP_PointData Data;

    private void Start()
    {
        GetComponentInChildren<Renderer>().material.color = Data.Color;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.Instance.AddXP(Data.XP);
            XP_PointsManager.RestartXP(this);
        }
    }
}
