using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    public MechCanvas myMenu;


    private void OnMouseDown()
    {
        GameManager.DestroyMech(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
