using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Point : MonoBehaviour
{
    public XP_PointData Data;
    public static GameObject XP_Prefab;

    private void Awake()
    {
        XP_Prefab = Resources.Load<GameObject>("XP Drops/XP");
    }

    private void Start()
    {
        GetComponentInChildren<Renderer>().material.color = Data.Color;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.Instance.AddXP(Data.XP);
            Destroy(gameObject);
        }
    }

    public static GameObject GetXP(XP_PointData data)
    {
        if (XP_Prefab == null)
        {
            XP_Prefab = Resources.Load<GameObject>("XP Drops/XP");
        }

        GameObject xp = Instantiate(XP_Prefab);
        xp.GetComponent<XP_Point>().Data = data as XP_PointData;
        return xp;
    }
}
