using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public List<MechCanvas> uiMech;

    public static UiManager Instance;

    public Transform mechList;
    public GameObject mechControlPrefab;


    public void Awake()
    {
        Instance = this;
    }

    public static void CloseAll(int index)
    {
        for (int i = 0; i < Instance.uiMech.Count; i++)
        {
            Instance.uiMech[i].CanvasClose(index > Instance.uiMech[i].index);
        }
    }

    public static void NewMech(Mech newMech)
    {
        var mc = Instantiate(Instance.mechControlPrefab, Instance.mechList).GetComponent<MechCanvas>();
        mc.myMech = newMech;
        newMech.myMenu = mc;
    }

    public static void RemoveMech(Mech removedMech)
    {
        var menu = removedMech.myMenu;
        menu.Destroy();
    }
}