using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public List<MechCanvas> uiMech;

    public static UiManager Instance;

    public void Start()
    {
        Instance = this;
    }

    public static void CloseAll()
    {
        foreach (var mechCanvas in Instance.uiMech)
        {
            mechCanvas.CanvasClose();
        }
    }
}
