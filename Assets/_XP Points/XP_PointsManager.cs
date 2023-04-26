using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_PointsManager : MonoBehaviour
{
    public static XP_PointsManager instance;

    public static GameObject XP_Prefab;

    public List<XP_Point> XP_Points;

    private void Awake()
    {
        instance = this;
        XP_Prefab = Resources.Load<GameObject>("XP Drops/XP");
    }

    public static void DropXP(XP_PointData xpData, Vector3 position)
    {
        foreach (XP_Point xp in instance.XP_Points)
        {
            if(xp.gameObject.activeSelf)
            {
                continue;
            }

            xp.gameObject.SetActive(true);
            xp.transform.position = position;
            xp.Data = xpData;
            return;
        }

        GameObject newXP = Instantiate(XP_Prefab, parent: instance.transform);
        XP_Point xpComp = newXP.GetComponent<XP_Point>();
        xpComp.Data = xpData;
        newXP.transform.position = position;
        instance.XP_Points.Add(xpComp);
    }

    public static void RestartXP(XP_Point xp)
    {
        xp.gameObject.SetActive(false);
    }

}
