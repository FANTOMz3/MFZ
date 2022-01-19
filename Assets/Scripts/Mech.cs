using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mech : MonoBehaviour
{
    public String name;

    public MechCanvas myMenu;

    private void Start()
    {
        var serialNumberInt = Random.Range(0, 999999);
        var serialNumberString = (6 - serialNumberInt.ToString().Length) * '0' + serialNumberInt.ToString();
        SetName($"Mech №{serialNumberString}");
    }

    public void SetName(string newName)
    {
        name = newName;
        myMenu.UpdateName();
    }
    
    private void OnMouseDown()
    {
        GameManager.DestroyMech(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
