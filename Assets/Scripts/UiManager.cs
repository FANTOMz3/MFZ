using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public List<MechCanvas> uiMech;

    public static UiManager Instance;

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
}
